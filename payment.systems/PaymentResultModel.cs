namespace payment.systems
{
    public class PaymentResultModel
    {
        /// <summary>
        /// Payment system type
        /// </summary>
        public PaymentSystemType PaymentSystem { get; set; }

        /// <summary>
        /// Order number from a payment system
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// Order number in the site DB
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Return url
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}