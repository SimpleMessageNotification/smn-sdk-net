using Smn;
using Smn.Request.Publish;
using Smn.Response.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smn_sdk_net_example
{
    class PublishDocDemo
    {
        public static void Main(string[] args)
        {
            // 初始化client
            SmnClient smnClient = new SmnClient(
                    "YourUserName",
                    "YourDomainName",
                    "YourPlainPassword",
                    "YourRegionName");

            // 设置请求对象
            PublishRequest request = new PublishRequest
            {
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:create_test_csharp3",
                Subject = "hello csharp",
                Message = "a test messag from csharp sdk"
            };
            try
            {
                // 发送请求并返回响应
                PublishResponse response = smnClient.SendRequest(request);
                string result = response.MessageId;
                Console.WriteLine("{0}", result);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
                Console.ReadLine();
            }
        }
    }
}
