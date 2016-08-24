namespace payment.systems.manual.InternetBank
{
    public class InternetBankPaymentsOptions : ManualPaymentsOptions
    {
        public InternetBankPaymentsOptions()
        {
            this.PaymentSystemType = systems.PaymentSystemType.InternetBank.ToString();

            this.Title = "InternetBank";
        }
    }
}