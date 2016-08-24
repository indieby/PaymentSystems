using System;
using Owin;
using payment.systems.manual.ATM;
using payment.systems.manual.BankTransfer;
using payment.systems.manual.Cash;
using payment.systems.manual.InternetBank;
using payment.systems.manual.Mobile;

namespace payment.systems.manual
{
    public static class ManualPaymentsExtensions
    {
        public static IAppBuilder UseMobilePayments(this IAppBuilder app, MobilePaymentsOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            app.Use(typeof (MobilePaymentsMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseATMPayments(this IAppBuilder app, ATMPaymentsOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            app.Use(typeof(ATMPaymentsMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseCashPayments(this IAppBuilder app, CashPaymentsOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            app.Use(typeof(CashPaymentsMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseInternetBankPayments(this IAppBuilder app, InternetBankPaymentsOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            app.Use(typeof(InternetBankPaymentsMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseBankTransferPayments(this IAppBuilder app, BankTransferPaymentsOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            app.Use(typeof(BankTransferPaymentsMiddleware), app, options);

            return app;
        }
    }
}