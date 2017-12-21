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
    /// list subscriptions response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class ListSubscriptionsByTopicResponse : BaseResponse
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
}
