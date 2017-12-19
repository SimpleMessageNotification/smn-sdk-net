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
using Smn.Response.Topic;
using Smn.Util;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace Smn.Request.Topic
{
    ///<summary> 
    /// delete topic request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
    public class DeleteTopicRequest : AbstractRequest<DeleteTopicResponse>
    {
        /// <summary>
        /// topic urn
        /// </summary>
        private string topicUrn;

        [DataMember(Name = "topic_urn")]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.DELETE;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(TopicUrn))
            {
                throw new ArgumentException("topic urn is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.TOPICS)
                    .Append(Constants.URL_DELIMITER).Append(TopicUrn);
            return sb.ToString();
        }
    }
}
