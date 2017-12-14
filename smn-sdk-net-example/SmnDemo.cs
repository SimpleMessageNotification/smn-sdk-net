using Smn;
using Smn.Request.Sms;
using Smn.Response.Sms;
using System;

namespace Smn.Example
{
    class SmnDemo
    {
        static SmnClient smnClient;
        public static void Main(string[] args)
        {
            // 初始化client
            smnClient = new SmnClient(
                "YouUserName",
                "YouDomainName", 
                "YouPassword", 
                "YouRegionId");

            //sms publish
            SmsPublish();
            // list sms sings
            ListSmsSigns();
            // delete sms sign
            DeleteSmsSign();
            // list sms msg report
            ListSmsMsgReport();
        }

        /// <summary>
        /// 发送短信通知验证码
        /// </summary>
        public static void SmsPublish()
        {
            // 设置请求对象
            SmsPublishRequest request = new SmsPublishRequest
            {
                // 发送手机号码 号码格式 (+)(国家码)(手机号码)
                Endpoint = "+86136*****587",
                // 短信签名必填,需要在消息通知服务的自助页面申请签名，申请办理时间约2天
                SignId = "6be340e91e5241e4b5d85837e6709104",
                Message = "您的验证码是:1234，请查收"
            };
            try
            {
                // 发送请求并返回响应
                SmsPublishResponse response = smnClient.SendRequest(request);
                string result = response.MessageId;
                Console.WriteLine("{0}", result);
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 查询短信签名
        /// </summary>
        public static void ListSmsSigns()
        {
            // 设置请求对象
            ListSmsSignsRequest request = new ListSmsSignsRequest();
            try
            {
                // 发送请求并返回响应
                ListSmsSignsResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", Convert.ToString(response));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 删除短信签名
        /// </summary>
        public static void DeleteSmsSign()
        {
            // 设置请求对象
            DeleteSmsSignRequest request = new DeleteSmsSignRequest
            {
                SignId = "359cc8d7676d45ac87970d305dc02321",
            };
            try
            {
                // 发送请求并返回响应
                DeleteSmsSignResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", response.RequestId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 查询短信的发送状态
        /// </summary>
        public static void ListSmsMsgReport()
        {
            // 设置请求对象
            ListSmsMsgReportRequest request = new ListSmsMsgReportRequest
            {
                StartTime = "1512625955366",
                EndTime = "1512712355850",
                SignId = "6be340e91e5241e4b5d85837e6709104",
            };
            try
            {
                // 发送请求并返回响应
                ListSmsMsgReportResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", response.Count);
                Console.WriteLine("{0}", response.Data.Count);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
