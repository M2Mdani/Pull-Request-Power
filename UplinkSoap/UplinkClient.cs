using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UplinkSoap.Properties;
using UplinkSoap.UplinkSoapCommunication;

namespace UplinkSoap
{
    public static class UplinkClient
    {
        public static async Task<NotifyDialersViaM2MResponseBody> NotifyDialersViaM2M(NotifyDialersViaM2MRequestBody ndr)
        {
       
            // Not sure if it is need to create an instance of this every time
            using (var m2mUplink = new M2MServiceSoapClient("M2MServiceSoap"))
            {
                var a = await m2mUplink.NotifyDialersViaM2MAsync(ndr.UserName, ndr.Password, ndr.dfLogID, ndr.MSISDN,
                ndr.NotificationType, ndr.CSPhoneNo, ndr.CSAccountNo, ndr.CSEventCode,
                ndr.TxRetry, ndr.ErrorCode, ndr.ErrorText);
                return a.Body;
            }
        }

        public static async Task<ReturnDialResultResponse> ReturnDialResult(
            string UserName, string Password,
            long DialLogID, int ErrorCode, string ErrorText)
        {
            string s = Settings.Default.MySetting1;
            using (M2MServiceSoapClient m2mUplink = new M2MServiceSoapClient("M2MServiceSoap"))
            {
                return await m2mUplink.ReturnDialResultAsync(UserName, Password, DialLogID, ErrorCode, ErrorText);
            }
        }

    }
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        NotifyDialersViaM2MRequestBody ndr = new NotifyDialersViaM2MRequestBody()
    //        {
    //            UserName = "m2mservice",
    //            Password = "F33M!1dk",
    //            dfLogID = 12345678,
    //            MSISDN = "0003061668",
    //            NotificationType = 5004,
    //            CSPhoneNo = "8552209737",
    //            CSAccountNo = "0006",
    //            CSEventCode = "140101002",
    //            TxRetry = 8,
    //        };
    //        NotifyDialersViaM2MResponseBody notifyDialersViaM2MResponse = null;
    //        try
    //        {

    //            notifyDialersViaM2MResponse = UplinkClient.NotifyDialersViaM2M(ndr).Result;
    //        }
    //        catch (Exception e)
    //        {
    //            Console.Write("fawf");
    //        }
    //        ;
    //        Console.Write(notifyDialersViaM2MResponse);
    //    }
    //}

}
