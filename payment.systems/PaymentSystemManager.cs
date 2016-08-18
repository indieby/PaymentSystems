using System;
using System.Collections.Generic;
using Microsoft.Owin;

namespace payment.systems
{
    internal class PaymentSystemManager : IPaymentSystemManager
    {
        private readonly IOwinContext _context;
        private readonly IOwinRequest _request;

        public PaymentSystemManager(IOwinContext context)
        {
            _context = context;
            _request = _context.Request;
        }

        public IDictionary<string, PaymentSystemOptions> GetPaymentSystemTypes()
        {
            return _request.Get<IDictionary<string, PaymentSystemOptions>>(PaymentSystemsConstants.PaymentSystemsKey);
        }

        /// <summary>
        /// Send authorization request to payment system
        /// </summary>
        /// <param name="paymentSystemType"></param>
        /// <param name="orderNumber"></param>
        /// <param name="orderAmount"></param>
        /// <param name="orderComment"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="returnUrl"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <returns>Redirect uri</returns>
        public string Authorize(PaymentSystemType paymentSystemType, string orderNumber, decimal orderAmount,
            string orderComment, string firstName, string lastName, string email, string mobilePhone, string returnUrl)
        {
            var paymentSystemTypes = GetPaymentSystemTypes();

            if (!paymentSystemTypes.ContainsKey(paymentSystemType.ToString()))
                throw new Exception("Provided payment system type not registered");

            var authorizeRequest = GetPaymentSystemTypes()[paymentSystemType.ToString()].AuthorizeRequestFunc;

            return authorizeRequest?.Invoke(orderNumber, orderAmount, orderComment, firstName, lastName, email, mobilePhone, returnUrl);
        }

        public string GetInfo(PaymentSystemType paymentSystemType)
        {
            var paymentSystemTypes = GetPaymentSystemTypes();

            if (!paymentSystemTypes.ContainsKey(paymentSystemType.ToString()))
                throw new Exception("Provided payment system type not registered");

            return GetPaymentSystemTypes()[paymentSystemType.ToString()].Description;
        }

        public PaymentSystemsConstants.PaymentStatus CheckPaymentStatus(string orderNumber, PaymentSystemType paymentSystem)
        {
            var paymentSystemTypes = GetPaymentSystemTypes();

            if (!paymentSystemTypes.ContainsKey(paymentSystem.ToString()))
                throw new Exception("Provided payment system type not registered");

            var checkPayment = GetPaymentSystemTypes()[paymentSystem.ToString()].CheckPaymentStatusFunc;

            return checkPayment.Invoke(orderNumber);
        }
    }
}