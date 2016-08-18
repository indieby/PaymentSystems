using System;

namespace payment.systems.assist
{
    internal class CheckPaymentResultModel
    {
        public CheckPaymentResultModelValues order { get; set; }
    }

    internal class CheckPaymentResultModelValues
    {
        public string ordernumber { get; set; }
        public string responsecode { get; set; }
        public string recommendation { get; set; }
        public string message { get; set; }
        public string ordercomment { get; set; }
        public string orderdate { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string meantypename { get; set; }
        public string meannumber { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string issuebank { get; set; }
        public string Email { get; set; }
        public string bankcountry { get; set; }
        public string rate { get; set; }
        public string approvalcode { get; set; }
        public string meansubtype { get; set; }
        public string cardholder { get; set; }
        public string ipaddress { get; set; }
        public string protocoltypename { get; set; }
        public string testmode { get; set; }
        public string customermessage { get; set; }
        public string orderstate { get; set; }
        public string processingname { get; set; }
        public string operationtype { get; set; }
        public string billnumber { get; set; }
        public string orderamount { get; set; }
        public string ordercurrency { get; set; }
        public string slipno { get; set; }
        public string packetdate { get; set; }
        public string signature { get; set; }
    }
}