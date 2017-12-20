using Smn;
using Smn.Request.Publish;
using Smn.Response.Publish;
using System;
using System.Collections.Generic;

namespace Smn.Example
{
    class PublishDemo
    {
        private SmnClient smnClient;
        public PublishDemo(SmnClient smnClient)
        {
            this.smnClient = smnClient;
        }

        /// <summary>
        /// 消息发布
        /// </summary>
        public void PublishWithMessage()
        {
            // 设置请求对象
            PublishRequest request = new PublishRequest
            {
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:create_by_zhangyx_test_csharp",
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
            }
        }

        /// <summary>
        /// 使用消息结构体方式的消息发布
        /// </summary>
        public void PublishWithMessageStructure()
        {
            // 设置请求对象
            PublishWithStrctureRequest request = new PublishWithStrctureRequest
            {
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:create_by_zhangyx_test_csharp",
                Subject = "hello csharp",
                MessageStructure = "{" +
                                    "\"default\":\"test by zhangyx structure\"," +
                                    "\"email\":\"test by zhangyx structure email\"," +
                                    "\"sms\":\"test by zhangyx structure _sms\"}"
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
            }
        }

        /// <summary>
        /// 使用消息模板方式的消息发布
        /// </summary>
        public void PublishWithMessageTemplate()
        {
            // 设置请求对象
            PublishWithTemplateRequest request = new PublishWithTemplateRequest
            {
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:create_by_zhangyx_test_csharp",
                Subject = "hello csharp",
                MessageTemplateName = "createMessageTemplate",
                Tags = new Dictionary<string, string>
                {
                    {"year","2018"},{"company","hellokitty"}
                },
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
            }
        }

    }
}
