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
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Smn.Response.Sms
{
    ///<summary> 
    /// list sms event response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class ListSmsEventResponse : BaseResponse
    {
        /// <summary>
        /// callback
        /// </summary>
        private List<SmsCallback> callback;

        /// <summary>
        /// topic_urn
        /// </summary>
        private string topicUrn;

        [JsonProperty("callback")]
        public List<SmsCallback> Callback { get => callback; set => callback = value; }

        [JsonProperty("topic_urn")]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }
    }

    /// <summary>
    /// sms event callback info
    /// author:zhangyx
    /// version:1.0.0
    /// </summary>
    public class SmsCallback
    {
        /// <summary>
        /// event_type
        /// </summary>
        private string eventType;

        /// <summary>
        /// topic_urn
        /// </summary>
        private string topicUrn;

        [JsonProperty("event_type")]
        public string EventType { get => eventType; set => eventType = value; }
        [JsonProperty("topic_urn")]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }
    }
}
