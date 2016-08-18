using Microsoft.Owin;
using Owin;

namespace payment.systems.assist
{
    public class AssistPaymentsMiddleware : PaymentSystemMiddleware<AssistPaymentsOptions>
    {
        public AssistPaymentsMiddleware(OwinMiddleware next, IAppBuilder app, AssistPaymentsOptions options) : base(next, options)
        {
        }

        protected override PaymentSystemHandler<AssistPaymentsOptions> CreateHandler()
        {
            return new AssistPaymentsHandler();
        }
    }
}
