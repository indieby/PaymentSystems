using Microsoft.Owin;
using Owin;

namespace payment.systems.manual.Mobile
{
    public class MobilePaymentsMiddleware : PaymentSystemMiddleware<ManualPaymentsOptions>
    {
        public MobilePaymentsMiddleware(OwinMiddleware next, IAppBuilder app, MobilePaymentsOptions options) : base(next, options)
        {
        }

        protected override PaymentSystemHandler<ManualPaymentsOptions> CreateHandler()
        {
            return new ManualPaymentsHandler();
        }
    }
}
