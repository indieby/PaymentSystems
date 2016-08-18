namespace payment.systems
{
    public struct PaymentSystemsConstants
    {
        internal static string PaymentSystemsKey = "paymentSystems";

        public enum PaymentStatus
        {
            Success,
            Failure,
            InProgress   
        }
    }
}