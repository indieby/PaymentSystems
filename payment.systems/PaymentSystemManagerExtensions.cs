using Microsoft.Owin;

namespace payment.systems
{
    public static class PaymentSystemManagerExtensions
    {
        private static IPaymentSystemManager _paymentSystemManager;

        public static IPaymentSystemManager PaymentSystemManager(this IOwinContext context)
        {
            return _paymentSystemManager ?? (_paymentSystemManager = new PaymentSystemManager(context));
        }
    }
}