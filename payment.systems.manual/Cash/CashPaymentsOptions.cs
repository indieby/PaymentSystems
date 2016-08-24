namespace payment.systems.manual.Cash
{
    public class CashPaymentsOptions : ManualPaymentsOptions
    {
        public CashPaymentsOptions()
        {
            this.PaymentSystemType = systems.PaymentSystemType.Cash.ToString();

            this.Title = "Cash";
        }
    }
}