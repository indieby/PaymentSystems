namespace payment.systems.assist
{
    internal struct Constants
    {
        public static string billnumber = "billnumber";
        public static string ordernumber = "ordernumber";

        public static string Merchant_ID_Key = "Merchant_ID";

        public static string Login_Key = "Login";
        public static string Password_Key = "Password";

        public static string Format_Key = "Format";

        #region Authorize request parameters
        public static string Order_Number_Key = "OrderNumber";
        public static string Order_Amount_Key = "OrderAmount";
        public static string Order_Comment_Key = "Order_Comment";
        public static string URL_Return_Key = "URL_Return";
        public static string First_Name = "Firstname";
        public static string Last_Name = "Lastname";
        public static string Email = "Email";
        public static string Mobile_Phone = "MobilePhone";

        #endregion

        public struct OrderState
        {
            public const string InProcess = "In Process";
            public const string Delayed = "Delayed";
            public const string Approved = "Approved";
            public const string PartialApproved = "PartialApproved";
            public const string PartialDelayed = "PartialDelayed";
            public const string Canceled = "Canceled";
            public const string PartialCanceled = "PartialCanceled";
            public const string Declined = "Declined";
            public const string Timeout = "Timeout";
        }
    }
}