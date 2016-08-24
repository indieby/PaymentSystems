using Microsoft.Owin;
using Owin;

namespace payment.systems.manual.Cash
{
    public class CashPaymentsMiddleware : PaymentSystemMiddleware<ManualPaymentsOptions>
    {
        public CashPaymentsMiddleware(OwinMiddleware next, IAppBuilder app, ManualPaymentsOptions options) : base(next, options)
        {
        }

        protected override PaymentSystemHandler<ManualPaymentsOptions> CreateHandler()
        {
            return new ManualPaymentsHandler();
        }
    }
}