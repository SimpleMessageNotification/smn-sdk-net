/*
 * Copyright (C) 2017. Huawei Technologies Co., LTD. All rights reserved.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of Apache License, Version 2.0.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * Apache License, Version 2.0 for more details.
 */
using Smn.Http;
using Smn.Response.Sms;
using Smn.Util;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// update sms event request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
    public class UpdateSmsEventRequest : AbstractRequest<UpdateSmsEventResponse>
    {
        /// <summary>
        /// callback
        /// </summary>
        private List<SmsCallbackRequestData> callback;

        [DataMember(Name = "callback")]
        public List<SmsCallbackRequestData> Callback { get => callback; set => callback = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.PUT;
        }

        public override string GetUrl()
        {
            if (callback == null || callback.Count == 0)
            {
                throw new ArgumentException("callback is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_SMS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.CALLBACK);
            return sb.ToString();
        }
    }

    /// <summary>
    /// sms event callback update request info
    /// author:zhangyx
    /// version:1.0.0
    /// </summary>
    [DataContract]
    public class SmsCallbackRequestData
    {
        /// <summary>
        /// event_type
        /// </summary>
        private string eventType;

        /// <summary>
        /// topic_urn
        /// </summary>
        private string topicUrn;

        [DataMember(Name = "event_type")]
        public string EventType { get => eventType; set => eventType = value; }
        [DataMember(Name = "topic_urn")]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }
    }
}
