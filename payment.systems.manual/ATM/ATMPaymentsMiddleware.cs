using Microsoft.Owin;
using Owin;

namespace payment.systems.manual.ATM
{
    public class ATMPaymentsMiddleware: PaymentSystemMiddleware<ManualPaymentsOptions>
    {
        public ATMPaymentsMiddleware(OwinMiddleware next, IAppBuilder app, ATMPaymentsOptions options) : base(next, options)
        {
        }

        protected override PaymentSystemHandler<ManualPaymentsOptions> CreateHandler()
        {
            return new ManualPaymentsHandler();
        }
    }
}