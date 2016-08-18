using System;
using System.Collections.Generic;

namespace payment.systems
{
    public interface IPaymentSystemManager
    {
        IDictionary<string, PaymentSystemOptions> GetPaymentSystemTypes();

        string Authorize(PaymentSystemType paymentSystemType, string orderNumber, decimal orderAmount,
            string orderComment, string firstName, string lastName, string email, string mobilePhone, string returnUrl);

        string GetInfo(PaymentSystemType paymentSystemType);

        PaymentSystemsConstants.PaymentStatus CheckPaymentStatus(string billNumber, PaymentSystemType paymentSystem);
    }
}