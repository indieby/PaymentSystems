using Microsoft.Owin;
using Owin;

namespace payment.systems.manual.ATM
{
    public class BankTransferPaymentsMiddleware : PaymentSystemMiddleware<ManualPaymentsOptions>
    {
        public BankTransferPaymentsMiddleware(OwinMiddleware next, IAppBuilder app, ManualPaymentsOptions options) : base(next, options)
        {
        }

        protected override PaymentSystemHandler<ManualPaymentsOptions> CreateHandler()
        {
            return new ManualPaymentsHandler();
        }
    }
}