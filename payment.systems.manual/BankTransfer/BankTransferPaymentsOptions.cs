namespace payment.systems.manual.BankTransfer
{
    public class BankTransferPaymentsOptions : ManualPaymentsOptions
    {
        public BankTransferPaymentsOptions()
        {
            this.PaymentSystemType = systems.PaymentSystemType.BankTransfer.ToString();

            this.Title = "BankTransfer";
        }
    }
}