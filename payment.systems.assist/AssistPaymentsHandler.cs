using System.Threading.Tasks;

namespace payment.systems.assist
{
    public class AssistPaymentsHandler : PaymentSystemHandler<AssistPaymentsOptions>
    {
        public override Task<bool> InvokeAsync()
        {
            if (Options.CallbackPath.Equals(Request.Path))
            {
                var billNumber = Request.Query.Get(Constants.billnumber);
                var orderNumber = Request.Query.Get(Constants.ordernumber);
                var returnUrl = Request.Query.Get(nameof(PaymentResultModel.ReturnUrl));

                var model = new PaymentResultModel
                {
                    BillNumber = billNumber,
                    OrderNumber = orderNumber,
                    PaymentSystem = PaymentSystemType.Assist,
                    ReturnUrl = returnUrl
                };

                RedirectToProcess(model, Context);

                return Task.FromResult(true);
            }

            return base.InvokeAsync();
        }

        public override Task TeardownAsync()
        {
            return base.TeardownAsync();
        }
    }
}