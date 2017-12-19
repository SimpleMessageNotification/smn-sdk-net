using Smn;
using Smn.Request.Topic;
using Smn.Response.Topic;
using System;

namespace Smn.Example
{
    class TopicDemo
    {
        private SmnClient smnClient;
        public TopicDemo(SmnClient smnClient)
        {
            this.smnClient = smnClient;
        }

        /// <summary>
        /// 创建topic
        /// </summary>
        public void CreateTopic()
        {
            // 设置请求对象
            CreateTopicRequest request = new CreateTopicRequest
            {
                Name = "create_by_zhangyx_test_csharp",
                DisplayName = "testtyc12020016",
            };
            try
            {
                // 发送请求并返回响应
                CreateTopicResponse response = smnClient.SendRequest(request);
                string result = response.TopicUrn;
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
        /// 更新topic
        /// </summary>
        public void UpdateTopic()
        {
            // 设置请求对象
            UpdateTopicRequest request = new UpdateTopicRequest
            {
                DisplayName = "哈哈哈",
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:create_by_zhangyx_test_csharp"
            };
            try
            {
                // 发送请求并返回响应
                UpdateTopicResponse response = smnClient.SendRequest(request);
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
        /// 查询topic详情
        /// </summary>
        public void QueryTopicDetail()
        {
            // 设置请求对象
            QueryTopicDetailRequest request = new QueryTopicDetailRequest
            {
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:create_by_zhangyx_test_csharp"
            };
            try
            {
                // 发送请求并返回响应
                QueryTopicDetailResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", response);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 查询topics列表
        /// </summary>
        public void ListTopics()
        {
            // 设置请求对象
            ListTopicsRequest request = new ListTopicsRequest
            {
                Limit = 10,
                Offset = 0,

            };
            try
            {
                // 发送请求并返回响应
                ListTopicsResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", response);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 删除topic
        /// </summary>
        public void DeleteTopic()
        {
            // 设置请求对象
            DeleteTopicRequest request = new DeleteTopicRequest
            {
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:create_by_zhangyx_test_csharp"
            };
            try
            {
                // 发送请求并返回响应
                DeleteTopicResponse response = smnClient.SendRequest(request);
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
