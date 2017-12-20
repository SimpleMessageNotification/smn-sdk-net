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

namespace Smn.Response.Topic
{
    ///<summary> 
    /// create topic response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class CreateTopicResponse : BaseResponse
    {
        /// <summary>
        /// topic_urn
        /// </summary>
        private string topicUrn;

        [JsonProperty("topic_urn")]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }
    }
}
