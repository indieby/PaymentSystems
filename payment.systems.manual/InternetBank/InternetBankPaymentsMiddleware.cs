using Microsoft.Owin;
using Owin;

namespace payment.systems.manual.InternetBank
{
    public class InternetBankPaymentsMiddleware : PaymentSystemMiddleware<ManualPaymentsOptions>
    {
        public InternetBankPaymentsMiddleware(OwinMiddleware next, IAppBuilder app, ManualPaymentsOptions options) : base(next, options)
        {
        }

        protected override PaymentSystemHandler<ManualPaymentsOptions> CreateHandler()
        {
            return new ManualPaymentsHandler();
        }
    }
}