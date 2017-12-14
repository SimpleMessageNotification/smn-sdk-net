using Smn;
using Smn.Request.Sms;
using Smn.Response.Sms;
using System;

namespace Smn.Example
{
    class SmnDemo
    {
        public static void Main(string[] args)
        {
            // 初始化client
            SmnClient smnClient = new SmnClient(
                "youUserName", 
                "youDomainName", 
                "youPassword", 
                "cn-north-1");
            // 设置请求对象
            SmsPublishRequest request = new SmsPublishRequest
            {
                // 发送手机号码 号码格式 (+)(国家码)(手机号码)
                Endpoint = "+8613688807587",  
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
                Console.WriteLine("{0}", e.Message);//
            }
        }
    }
}
