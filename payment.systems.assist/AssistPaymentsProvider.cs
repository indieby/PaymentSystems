using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Xml;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace payment.systems.assist
{
    public static class AssistPaymentsProvider
    {
        public static Func<string, decimal, string, string, string, string, string, string, string> GetAuthorizeRequest(
            AssistPaymentsOptions options)
        {
            return (orderNumber, orderAmount, orderComment, firstName, lastName, email, mobilePhone, returnUrl) =>
            {
                using (var client = new HttpClient())
                {
                    var requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        Content = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            {Constants.Merchant_ID_Key, options.Merchant_ID},
                            {Constants.Order_Number_Key, orderNumber},
                            {Constants.Order_Amount_Key, orderAmount.ToString(CultureInfo.InvariantCulture)},
                            {Constants.Order_Comment_Key, orderComment},
                            {Constants.First_Name, firstName},
                            {Constants.Last_Name, lastName},
                            {Constants.Email, email},
                            {Constants.Mobile_Phone, mobilePhone},
                            {
                                Constants.URL_Return_Key,
                                new Uri(new Uri(new Uri(returnUrl).GetLeftPart(UriPartial.Authority)),
                                    options.CallbackPath.Add(new QueryString(nameof(returnUrl), returnUrl))).ToString()
                            }
                        }),
                        RequestUri = new Uri(options.AuthorizeUrl)
                    };

                    var response = client.SendAsync(requestMessage).Result;

                    var redirectLocation = response.RequestMessage.RequestUri;

                    return redirectLocation.ToString();
                }
            };
        }

        public static Func<string, PaymentSystemsConstants.PaymentStatus> GetCheckStatusRequest(
            AssistPaymentsOptions options)
        {
            return orderNumber =>
            {
                using (var client = new HttpClient())
                {
                    var requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        Content = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            {Constants.Order_Number_Key, orderNumber},
                            {Constants.Merchant_ID_Key, options.Merchant_ID},
                            {Constants.Login_Key, options.Login},
                            {Constants.Password_Key, options.Password},
                            {Constants.Format_Key, "3"} //XML
                        }),
                        RequestUri = new Uri(options.CheckPaymentStatusUrl)
                    };

                    var response = client.SendAsync(requestMessage).Result;

                    try
                    {
                        var xml = new XmlDocument();
                        xml.LoadXml(response.Content.ReadAsStringAsync().Result);

                        var result = xml["result"];

                        if (result == null)
                            throw new Exception($"Fail to parse xml response. Node 'result' is null");

                        var firstcode = result.Attributes["firstcode"].Value;

                        if (firstcode != "0")
                        {
                            var secondcode = result.Attributes["secondcode"].Value;
                            throw new Exception(
                                $"Fail to get orderstate. First code: {firstcode}, second code: {secondcode}");
                        }

                        var paymentResult =
                            JObject.Parse(JsonConvert.SerializeXmlNode(result["order"]))
                                .ToObject<CheckPaymentResultModel>();

                        switch (paymentResult.order.orderstate)
                        {
                            case Constants.OrderState.Approved:
                                return PaymentSystemsConstants.PaymentStatus.Success;

                            case Constants.OrderState.InProcess:
                            case Constants.OrderState.Delayed:
                                return PaymentSystemsConstants.PaymentStatus.InProgress;

                            case Constants.OrderState.Declined:
                            case Constants.OrderState.Canceled:
                            case Constants.OrderState.Timeout:
                                return PaymentSystemsConstants.PaymentStatus.Failure;

                            default:
                                return PaymentSystemsConstants.PaymentStatus.Failure;
                        }
                    }
                    catch (Exception ex)
                    {
                        options.ErrorLog($"Fail to check payment status: {ex.Message}");
                        throw;
                    }
                }
            };
        }
    }
}