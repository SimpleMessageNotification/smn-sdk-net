using Smn;
using Smn.Request.Subscription;
using Smn.Request.Topic;
using Smn.Response.Subscription;
using Smn.Response.Topic;
using Smn.Util;
using System;

namespace smn_sdk_net_example
{
    class TopicDocDemo
    {
        public static void Main(string[] args)
        {
            // 初始化client
            SmnClient smnClient = new SmnClient(
                    "YourUserName",
                    "YourDomainName",
                    "YourPlainPassword",
                    "YourRegionName");

            CreateTopicRequest request = new CreateTopicRequest
            {
                Name = "create_test_csharp3",
                DisplayName = "topic display name",
            };
            CreateTopicResponse createTopicResponse;
            try
            {
                // 发送请求并返回响应
                createTopicResponse = smnClient.SendRequest(request);
                string result = createTopicResponse.TopicUrn;
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
                Console.ReadLine();
                return;
            }

            // 设置请求对象
            SubscribeRequest subscribeRequest = new SubscribeRequest
            {
                TopicUrn = createTopicResponse.TopicUrn,
                Protocol = ProtocolType.SMS,
                Endpoint = "+8613688807587",
                Remark = "api订阅接口测试成功"
            };
            try
            {
                // 发送请求并返回响应
                SubscribeResponse subscribeResponse = smnClient.SendRequest(subscribeRequest);
                string result = subscribeResponse.RequestId;
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
