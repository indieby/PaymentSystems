namespace payment.systems.manual.ATM
{
    public class ATMPaymentsOptions : ManualPaymentsOptions
    {
        public ATMPaymentsOptions()
        {
            this.PaymentSystemType = systems.PaymentSystemType.ATM.ToString();

            this.Title = "ATM";
        }
    }
}