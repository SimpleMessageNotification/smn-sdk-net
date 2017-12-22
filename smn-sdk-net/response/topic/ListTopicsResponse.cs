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

namespace Smn.Response.Topic
{
    ///<summary> 
    /// list topics response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class ListTopicsResponse : BaseResponse
    {
        /// <summary>
        /// topic_count
        /// </summary>
        private int topicCount;

        /// <summary>
        /// topics
        /// </summary>
        private List<TopicInfo> topics;

        [JsonProperty("topic_count")]
        public int TopicCount { get => topicCount; set => topicCount = value; }
        [JsonProperty("topics")]
        public List<TopicInfo> Topics { get => topics; set => topics = value; }
    }

    /// <summary>
    /// topic data info
    /// </summary>
    public class TopicInfo
    {
        /// <summary>
        /// name
        /// </summary>
        private string name;

        /// <summary>
        /// topic_urn
        /// </summary>
        private string topicUrn;

        /// <summary>
        /// display_name
        /// </summary>
        private string displayName;

        /// <summary>
        /// push_policy
        /// </summary>
        private string pushPolicy;

        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("topic_urn")]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }
        [JsonProperty("display_name")]
        public string DisplayName { get => displayName; set => displayName = value; }
        [JsonProperty("push_policy")]
        public string PushPolicy { get => pushPolicy; set => pushPolicy = value; }
    }
}
