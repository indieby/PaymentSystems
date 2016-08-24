namespace payment.systems.manual.Mobile
{
    public class MobilePaymentsOptions : ManualPaymentsOptions
    {
        public MobilePaymentsOptions()
        {
            this.PaymentSystemType = systems.PaymentSystemType.Mobile.ToString();

            this.Title = "Mobile";
        }
    }
}