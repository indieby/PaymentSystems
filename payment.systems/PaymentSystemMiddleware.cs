using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace payment.systems
{
    public abstract class PaymentSystemMiddleware<TOptions> : OwinMiddleware where TOptions : PaymentSystemOptions
    {
        public TOptions Options { get; set; }

        protected PaymentSystemMiddleware(OwinMiddleware next, TOptions options) : base(next)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            Options = options;
        }

        public override async Task Invoke(IOwinContext context)
        {
            PaymentSystemHandler<TOptions> handler = CreateHandler();

            await handler.Initialize(Options, context);

            if (!await handler.InvokeAsync())
            {
                await Next.Invoke(context);
            }

            await handler.TeardownAsync();
        }

        protected abstract PaymentSystemHandler<TOptions> CreateHandler();
    }
}