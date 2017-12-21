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

namespace Smn.Response.Subscription
{
    ///<summary> 
    /// Subscribe response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class ListSubscriptionsResponse : BaseResponse
    {
        /// <summary>
        /// subscription_count
        /// </summary>
        private int subscriptionCount;

        /// <summary>
        /// subscriptions
        /// </summary>
        private List<SubscriptionInfo> subscriptions;

        [JsonProperty("subscription_count")]
        public int SubscriptionCount { get => subscriptionCount; set => subscriptionCount = value; }
        [JsonProperty("subscriptions")]
        public List<SubscriptionInfo> Subscriptions { get => subscriptions; set => subscriptions = value; }
    }

    ///<summary> 
    /// subscription info
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class SubscriptionInfo
    {
        /// <summary>
        /// topic_urn
        /// </summary>
        private string topicUrn;

        /// <summary>
        /// protocol
        /// </summary>
        private string protocol;

        /// <summary>
        /// subscription_urn
        /// </summary>
        private string subscriptionUrn;

        /// <summary>
        /// owner
        /// </summary>
        private string owner;

        /// <summary>
        /// endpoint
        /// </summary>
        private string endpoint;

        /// <summary>
        /// remark
        /// </summary>
        private string remark;

        /// <summary>
        /// status
        /// </summary>
        private int status;

        [JsonProperty("topic_urn")]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }
        [JsonProperty("protocol")]
        public string Protocol { get => protocol; set => protocol = value; }
        [JsonProperty("subscription_urn")]
        public string SubscriptionUrn { get => subscriptionUrn; set => subscriptionUrn = value; }
        [JsonProperty("owner")]
        public string Owner { get => owner; set => owner = value; }
        [JsonProperty("endpoint")]
        public string Endpoint { get => endpoint; set => endpoint = value; }
        [JsonProperty("remark")]
        public string Remark { get => remark; set => remark = value; }
        [JsonProperty("status")]
        public int Status { get => status; set => status = value; }
    }
}
