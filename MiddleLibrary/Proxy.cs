using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UplinkSoap.UplinkSoapCommunication;
using UplinkSoap;

namespace MiddleLibrary
{
    public class Proxy
    {
        public bool Write() { 
        NotifyDialersViaM2MRequestBody ndr = new NotifyDialersViaM2MRequestBody()
            {
                UserName = "m2mservice",
                Password = "F33M!1dk",
                dfLogID = 12345678,
                MSISDN = "0003061668",
                NotificationType = 5004,
                CSPhoneNo = "8552209737",
                CSAccountNo = "0006",
                CSEventCode = "140101002",
                TxRetry = 8,
            };

            try
            {
                using (var m2mUplink = new M2MServiceSoapClient("M2MServiceSoap"))
                {
                    var a = m2mUplink.NotifyDialersViaM2MAsync(ndr.UserName, ndr.Password, ndr.dfLogID, ndr.MSISDN,
                            ndr.NotificationType, ndr.CSPhoneNo, ndr.CSAccountNo, ndr.CSEventCode,
                            ndr.TxRetry, ndr.ErrorCode, ndr.ErrorText).Result;
                    ;
                }
            }
            catch (Exception e)
            {
                Console.Write("First request Failed!");
                return false;
            }
            NotifyDialersViaM2MResponseBody notifyDialersViaM2MResponseBody = null;
            try
            {
                notifyDialersViaM2MResponseBody = UplinkSoap.UplinkClient.NotifyDialersViaM2M(ndr).Result;
            }
            catch (Exception e)
            {
                Console.Write("Second request Failed!");
                return false;
            }

            Console.Write("3");
            while (true) {
                
                return true; }
            }
    }
}
