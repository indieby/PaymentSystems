using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace payment.systems
{
    public abstract class PaymentSystemHandler<TOptions> where TOptions : PaymentSystemOptions
    {
        protected IOwinContext Context { get; private set; }

        protected IOwinRequest Request => this.Context.Request;

        protected IOwinResponse Response => this.Context.Response;

        protected TOptions Options { get; private set; }

        public Task Initialize(TOptions options, IOwinContext context)
        {
            Options = options;
            Context = context;

            RegisterHandler(context);

            return Task.FromResult<object>(null);
        }

        public virtual Task<bool> InvokeAsync()
        {
            return Task.FromResult(false);
        }

        public virtual Task TeardownAsync()
        {
            return Task.FromResult<object>(null);
        }

        private void RegisterHandler(IOwinContext context)
        {
            IDictionary<string, PaymentSystemOptions> currentDictionary = context.Request.Get<IDictionary<string, PaymentSystemOptions>>(PaymentSystemsConstants.PaymentSystemsKey) ?? new Dictionary<string, PaymentSystemOptions>();

            if (!currentDictionary.ContainsKey(Options.PaymentSystemType))
            {
                currentDictionary.Add(Options.PaymentSystemType, Options);
            }

            context.Request.Set(PaymentSystemsConstants.PaymentSystemsKey, currentDictionary);
        }

        public void RedirectToProcess(PaymentResultModel paymentResultModel, IOwinContext context)
        {
            var uri =
                Options.ProcessResult_URL.Add(
                    new QueryString(nameof(paymentResultModel.BillNumber) + "=" + paymentResultModel.BillNumber + "&" +
                                    nameof(paymentResultModel.OrderNumber) + "=" + paymentResultModel.OrderNumber + "&" +
                                    nameof(paymentResultModel.ReturnUrl) + "=" + paymentResultModel.ReturnUrl));
            

            context.Response.Redirect(uri);
        }
    }
}