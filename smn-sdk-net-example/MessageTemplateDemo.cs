using Smn.Request.Template;
using Smn.Response.Template;
using Smn.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smn.Example
{
    class MessageTemplateDemo
    {
        private SmnClient smnClient;

        public MessageTemplateDemo(SmnClient smnClient)
        {
            this.smnClient = smnClient;
        }

        /// <summary>
        /// 创建消息模板
        /// </summary>
        public void CreateMessageTemplate()
        {
            // 设置请求对象
            CreateMessageTemplateRequest request = new CreateMessageTemplateRequest
            {
                MessageTemplateName = "template_create_by_zhangyx_test_csharp",
                Content = "this year is {year}",
                Protocol = ProtocolType.SMS,
            };
            try
            {
                // 发送请求并返回响应
                CreateMessageTemplateResponse response = smnClient.SendRequest(request);
                string result = response.MessageTemplateId;
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
        /// 删除消息模板
        /// </summary>
        public void DeleteMessageTemplate()
        {
            // 设置请求对象
            DeleteMessageTemplateRequest request = new DeleteMessageTemplateRequest
            {
                MessageTemplateId = "b925641f25bd409b9a51f27138dd066c",
            };
            try
            {
                // 发送请求并返回响应
                DeleteMessageTemplateResponse response = smnClient.SendRequest(request);
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
        /// 更新消息模板
        /// </summary>
        public void UpdateMessageTemplate()
        {
            // 设置请求对象
            UpdateMessageTemplateRequest request = new UpdateMessageTemplateRequest
            {
                MessageTemplateId = "cf1342072d034faeb7aaa92e276a3242",
                Content = "next year is {year}"
            };
            try
            {
                // 发送请求并返回响应
                UpdateMessageTemplateResponse response = smnClient.SendRequest(request);
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
        /// 查询消息模板列表
        /// </summary>
        public void ListMessageTemplates()
        {
            // 设置请求对象
            ListMessageTemplatesRequest request = new ListMessageTemplatesRequest
            {
                Limit = 10,
                Offset = 0,
                Protocol = ProtocolType.SMS,
                MessageTemplateName = "template_create_by_zhangyx_test_csharp"
            };
            try
            {
                // 发送请求并返回响应
                ListMessageTemplatesResponse response = smnClient.SendRequest(request);
                int result = response.MessageTemplateCount;
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
        /// 查询消息模板详情
        /// </summary>
        public void QueryMessageTemplateDetail()
        {
            // 设置请求对象
            QueryMessageTemplateDetailRequest request = new QueryMessageTemplateDetailRequest
            {
                MessageTemplateId = "a64abe240a7d4b829e7e7a83f486588d"
            };
            try
            {
                // 发送请求并返回响应
                QueryMessageTemplateDetailResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", response);
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
