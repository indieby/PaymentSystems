using System;
using Owin;

namespace payment.systems.assist
{
    public static class AssistPaymentsExtension
    {
        public static IAppBuilder UseAssistPayments(this IAppBuilder app, AssistPaymentsOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            app.Use(typeof (AssistPaymentsMiddleware), app, options);

            return app;
        }
    }
}