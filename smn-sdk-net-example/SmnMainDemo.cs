using Smn;
using Smn.Config;
using Smn.Request.Sms;
using Smn.Response.Sms;
using System;
using System.Collections.Generic;

namespace Smn.Example
{
    class SmnMainDemo
    {
        static SmnClient smnClient;

        //public static void Main(string[] args)
        //{
        //    // 初始化client
        //    smnClient = new SmnClient(
        //        "YourUserName",
        //        "YourDomainName",
        //        "YourPlainPassword",
        //        "YourRegionName");

        //    // if you want to customize the HTTP parameters,
        //    // or use http proxy, you can use like this
        //    //ClientConfiguration configuration = new ClientConfiguration
        //    //{
        //    //    Timeout = 80000,
        //    //    ProxyHost = "127.0.0.1",
        //    //    ProxyPort = 808,
        //    //    ProxyUsername = "break",
        //    //    ProxyPassword = "123456"
        //    //};
        //    //smnClient = new SmnClient(
        //    //    "YourUserName",
        //    //    "YourDomainName",
        //    //    "YourPlainPassword",
        //    //    "YourRegionName",
        //    //    configuration);

        //    SmsDemo smsDemo = new SmsDemo(smnClient);
        //    //sms publish
        //    smsDemo.SmsPublish();
        //    // list sms sings
        //    smsDemo.ListSmsSigns();
        //    // delete sms sign
        //    smsDemo.DeleteSmsSign();
        //    // list sms msg report
        //    smsDemo.ListSmsMsgReport();
        //    // get sended sms messsage content
        //    smsDemo.GetSmsMessage();
        //    //list sms event
        //    smsDemo.ListSmsEvent();
        //    //update sms event
        //    smsDemo.UpdateSmsEvent();

        //    TopicDemo topicDemo = new TopicDemo(smnClient);
        //    // create topic
        //    topicDemo.CreateTopic();
        //    // update topic
        //    topicDemo.UpdateTopic();
        //    // query topic detail
        //    topicDemo.QueryTopicDetail();
        //    // list topics
        //    topicDemo.ListTopics();
        //    // delete topic
        //    topicDemo.DeleteTopic();
        //    // update topic attribute
        //    topicDemo.UpdateTopicAttribute();
        //    //list topic attributes
        //    topicDemo.ListTopicAttributes();
        //    // delete all topic attributes
        //    topicDemo.DeleteTopicAttributes();
        //    // delete topic attribute by name
        //    topicDemo.DeleteTopicAttributeByName();

        //    PublishDemo publishDemo = new PublishDemo(smnClient);
        //    // publish message 
        //    publishDemo.PublishWithMessage();
        //    // publish with message structure
        //    publishDemo.PublishWithMessageStructure();
        //    // publish with message template
        //    publishDemo.PublishWithMessageTemplate();

        //    SubscriptionDemo subscriptionDemo = new SubscriptionDemo(smnClient);
        //    // list subscriptions
        //    subscriptionDemo.ListSubscriptions();
        //    // list subscriptions by topic
        //    subscriptionDemo.ListSubscriptionsByTopic();
        //    // Unsubscribe
        //    subscriptionDemo.Unsubscribe();
        //    // Subscribe
        //    subscriptionDemo.Subscribe();

        //    MessageTemplateDemo messageTemplateDemo = new MessageTemplateDemo(smnClient);
        //    // create message template
        //    messageTemplateDemo.CreateMessageTemplate();
        //    // delete message template 
        //    messageTemplateDemo.DeleteMessageTemplate();
        //    // update message template
        //    messageTemplateDemo.UpdateMessageTemplate();
        //    // list message templates
        //    messageTemplateDemo.ListMessageTemplates();
        //    // query message template detail 
        //    messageTemplateDemo.QueryMessageTemplateDetail();

        //}
    }
}
