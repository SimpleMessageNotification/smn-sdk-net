using Smn;
using Smn.Request.Subscription;
using Smn.Response.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smn.Example
{
    class SubscriptionDemo
    {
        private SmnClient smnClient;

        public SubscriptionDemo(SmnClient smnClient)
        {
            this.smnClient = smnClient;
        }

        /// <summary>
        /// 分页返回请求者的所有的订阅列表
        /// </summary>
        public void ListSubscriptions()
        {
            // 设置请求对象
            ListSubscriptionsRequest request = new ListSubscriptionsRequest
            {
                Limit = 10,
                Offset = 0,
            };
            try
            {
                // 发送请求并返回响应
                ListSubscriptionsResponse response = smnClient.SendRequest(request);
                int result = response.SubscriptionCount;
                Console.WriteLine("{0}", result);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 分页获取特定主题的订阅列表
        /// </summary>
        public void ListSubscriptionsByTopic()
        {
            // 设置请求对象
            ListSubscriptionsByTopicRequest request = new ListSubscriptionsByTopicRequest
            {
                Limit = 5,
                Offset = 0,
                TopicUrn ="urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:SmnApi"
            };
            try
            {
                // 发送请求并返回响应
                ListSubscriptionsByTopicResponse response = smnClient.SendRequest(request);
                int result = response.SubscriptionCount;
                Console.WriteLine("{0}", result);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        public void Unsubscribe()
        {
            // 设置请求对象
            UnsubscribeRequest request = new UnsubscribeRequest
            {
                SubscriptionUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:SmnApi:30605bffb98c471b884eaec18b9fe6a3",
            };
            try
            {
                // 发送请求并返回响应
                UnsubscribeResponse response = smnClient.SendRequest(request);
                string result = response.RequestId;
                Console.WriteLine("{0}", result);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 添加订阅
        /// </summary>
        public void Subscribe()
        {
            // 设置请求对象
            SubscribeRequest request = new SubscribeRequest
            {
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:SmnApi",
                Protocol = "email",
                Endpoint = "zhangyaxing@huawei.com",
                Remark = "api订阅接口测试成功"
            };
            try
            {
                // 发送请求并返回响应
                SubscribeResponse response = smnClient.SendRequest(request);
                string result = response.RequestId;
                Console.WriteLine("{0}", result);
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
