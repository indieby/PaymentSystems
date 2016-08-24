using Microsoft.Owin;

namespace payment.systems.assist
{
    public class AssistPaymentsOptions : PaymentSystemOptions
    {
        public AssistPaymentsOptions()
        {
            this.PaymentSystemType = systems.PaymentSystemType.Assist.ToString();

            this.Title = "ASSIST";

            this.AuthorizeUrl = "https://test.paysec.by/pay/order.cfm";

            this.CheckPaymentStatusUrl = "https://test.paysec.by/orderstate/orderstate.cfm";

            this.CallbackPath = new PathString("/processassistresult");

            this.AuthorizeRequestFunc = AssistPaymentsProvider.GetAuthorizeRequest(options: this);

            this.CheckPaymentStatusFunc = AssistPaymentsProvider.GetCheckStatusRequest(options: this);
        }

        public string Merchant_ID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public PathString CallbackPath { get; set; }
    }
}