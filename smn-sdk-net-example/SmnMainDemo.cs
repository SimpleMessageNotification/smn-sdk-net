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

        public static void Main(string[] args)
        {
            // 初始化client
            smnClient = new SmnClient(
               "YourUserName",
               "YourDomainName",
               "YourPlainPassword",
               "YourRegionName");

            // if you want to customize the HTTP parameters,
            // or use http proxy, you can use like this
            //ClientConfiguration configuration = new ClientConfiguration
            //{
            //    Timeout = 80000,
            //    ProxyHost = "127.0.0.1",
            //    ProxyPort = 808,
            //    ProxyUsername = "break",
            //    ProxyPassword = "123456"
            //};
            //smnClient = new SmnClient(
            //    "YourUserName",
            //    "YourDomainName",
            //    "YourPlainPassword",
            //    "YourRegionName",
            //    configuration);
            MmsDemo mmsDemo = new MmsDemo(smnClient);
            // send mms
            // 发送彩信
            mmsDemo.MmsPublish();

            smsdemo smsdemo = new smsdemo(smnclient);
            //sms publish
            smsdemo.smspublish();

            // sms batch pulish
            // 批量发送通知验证码类短信
            smsdemo.smsbatchpublish();

            // 批量发送不同内容的通知验证码类短信
            smsdemo.smsbatchpublishwithdiffmessage();

            // promotion sms publish
            // 批量发送推广类短信
            smsdemo.promotionsmspublish();

            //list sms templates
            smsdemo.listsmstemplates();

            // create sms template
            smsdemo.createsmstemplate();

            // delete sms template
            smsdemo.deletesmstemplate();

            // get sms template detail
            smsdemo.getsmstemplatedetail();

            // list sms sings
            smsdemo.listsmssigns();
            // delete sms sign
            smsdemo.deletesmssign();
            // list sms msg report
            smsdemo.listsmsmsgreport();
            // get sended sms messsage content
            smsdemo.getsmsmessage();
            //list sms event
            smsdemo.listsmsevent();
            //update sms event
            smsdemo.updatesmsevent();

            topicdemo topicdemo = new topicdemo(smnclient);
            // create topic
            topicdemo.createtopic();
            // update topic
            topicdemo.updatetopic();
            // query topic detail
            topicdemo.querytopicdetail();
            // list topics
            topicdemo.listtopics();
            // delete topic
            topicdemo.deletetopic();
            // update topic attribute
            topicdemo.updatetopicattribute();
            //list topic attributes
            topicdemo.listtopicattributes();
            // delete all topic attributes
            topicdemo.deletetopicattributes();
            // delete topic attribute by name
            topicdemo.deletetopicattributebyname();

            publishdemo publishdemo = new publishdemo(smnclient);
            // publish message 
            publishdemo.publishwithmessage();
            // publish with message structure
            publishdemo.publishwithmessagestructure();
            // publish with message template
            publishdemo.publishwithmessagetemplate();

            subscriptiondemo subscriptiondemo = new subscriptiondemo(smnclient);
            // list subscriptions
            subscriptiondemo.listsubscriptions();
            // list subscriptions by topic
            subscriptiondemo.listsubscriptionsbytopic();
            // unsubscribe
            subscriptiondemo.unsubscribe();
            // subscribe
            subscriptiondemo.subscribe();

            messagetemplatedemo messagetemplatedemo = new messagetemplatedemo(smnclient);
            // create message template
            messagetemplatedemo.createmessagetemplate();
            // delete message template 
            messagetemplatedemo.deletemessagetemplate();
            // update message template
            messagetemplatedemo.updatemessagetemplate();
            // list message templates
            messagetemplatedemo.listmessagetemplates();
            // query message template detail 
            messagetemplatedemo.querymessagetemplatedetail();
        }
    }
}
