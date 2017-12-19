using Smn;
using Smn.Request.Sms;
using Smn.Response.Sms;
using System;
using System.Collections.Generic;

namespace Smn.Example
{
    class SmsDemo
    {
        private SmnClient smnClient;

        public SmsDemo(SmnClient smnClient)
        {
            this.smnClient = smnClient;
        }

        /// <summary>
        /// 发送短信通知验证码
        /// </summary>
        public void SmsPublish()
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
                Console.ReadLine();
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
        public void ListSmsSigns()
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
        public void DeleteSmsSign()
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
        public void ListSmsMsgReport()
        {
            // 设置请求对象
            ListSmsMsgReportRequest request = new ListSmsMsgReportRequest
            {
                StartTime = "1512625955366",
                EndTime = "1512712355850",
                Limit = 99,
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

        /// <summary>
        /// 查询已发送短信的内容
        /// </summary>
        public void GetSmsMessage()
        {
            // 设置请求对象
            GetSmsMessageRequest request = new GetSmsMessageRequest
            {
                MessageId = "c90c791e54dd4c987c63b250982",
            };
            try
            {
                // 发送请求并返回响应
                GetSmsMessageResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", response.Message);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 查询短信回调事件
        /// </summary>
        public void ListSmsEvent()
        {
            // 设置请求对象
            ListSmsEventRequest request = new ListSmsEventRequest
            {
                EventType = "sms_fail_event",
            };
            try
            {
                // 发送请求并返回响应
                ListSmsEventResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", response.Callback);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// 更新短信回调事件
        /// </summary>
        public void UpdateSmsEvent()
        {
            SmsCallbackRequestData successCallbackData = new SmsCallbackRequestData
            {
                EventType = "sms_success_event",
                TopicUrn = "urn:smn:cn-north-1:cffe4fc4c9a54219b60dbaf7b586e132:sms_event_urn",
            };
            List<SmsCallbackRequestData> listSmsEvents = new List<SmsCallbackRequestData>();
            listSmsEvents.Add(successCallbackData);
            // 设置请求对象
            UpdateSmsEventRequest request = new UpdateSmsEventRequest
            {
                Callback = listSmsEvents,
            };
            try
            {
                // 发送请求并返回响应
                UpdateSmsEventResponse response = smnClient.SendRequest(request);
                Console.WriteLine("{0}", response.RequestId);
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
