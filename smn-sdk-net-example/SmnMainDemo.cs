using Smn;
using Smn.Request.Sms;
using Smn.Response.Sms;
using System;
using System.Collections.Generic;

namespace Smn.Example
{
    class SmnMainDemo
    {
        static SmnClient smnClient;
        public static void Main(string[] args)
        {
            // 初始化client
            smnClient = new SmnClient(
                "YourUserName",
                "YourDomainName",
                "YourPlainPassword",
                "YourRegionName");

            SmsDemo smsDemo = new SmsDemo(smnClient);
            //sms publish
            smsDemo.SmsPublish();
            // list sms sings
            smsDemo.ListSmsSigns();
            // delete sms sign
            smsDemo.DeleteSmsSign();
            // list sms msg report
            smsDemo.ListSmsMsgReport();
            // get sended sms messsage content
            smsDemo.GetSmsMessage();
            //list sms event
            smsDemo.ListSmsEvent();
            //update sms event
            smsDemo.UpdateSmsEvent();

            TopicDemo topicDemo = new TopicDemo(smnClient);
            // create topic
            topicDemo.CreateTopic();
            // update topic
            topicDemo.UpdateTopic();
            // query topic detail
            topicDemo.QueryTopicDetail();
            // list topics
            topicDemo.ListTopics();
            // delete topic
            topicDemo.DeleteTopic();
            // update topic attribute
            topicDemo.UpdateTopicAttribute();
            //list topic attributes
            topicDemo.ListTopicAttributes();
            // delete all topic attributes
            topicDemo.DeleteTopicAttributes();
            // delete topic attribute by name
            topicDemo.DeleteTopicAttributeByName();

            PublishDemo publishDemo = new PublishDemo(smnClient);
            // publish message 
            publishDemo.PublishWithMessage();
            // publish with message structure
            publishDemo.PublishWithMessageStructure();
            // publish with message template
            publishDemo.PublishWithMessageTemplate();

        }
    }
}
