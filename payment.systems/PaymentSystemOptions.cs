using System;
using Microsoft.Owin;

namespace payment.systems
{
    public abstract class PaymentSystemOptions
    {
        public Action<string> InfoLog { get; set; } 
        public Action<string> ErrorLog { get; set; } 

        public string PaymentSystemType { get; protected set; }

        public string Title { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// In: orderNumber, orderAmount, orderComment, returnUrl
        /// Out: redirect uri
        /// </summary>
        public Func<string, decimal, string, string, string, string, string, string, string> AuthorizeRequestFunc { get; set; }

        /// <summary>
        /// In: bill number
        /// Out: true/false
        /// </summary>
        public Func<string, PaymentSystemsConstants.PaymentStatus> CheckPaymentStatusFunc { get; set; }

        public string AuthorizeUrl { get; protected set; }

        public string CheckPaymentStatusUrl { get; protected set; }

        /// <summary>
        /// Url that must to process payment result
        /// </summary>
        public PathString ProcessResult_URL { get; set; }

        public bool IsService { get; protected set; }
    }
}