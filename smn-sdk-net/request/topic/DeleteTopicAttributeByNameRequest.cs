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
    /// delete topic attribute by name request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
    public class DeleteTopicAttributeByNameRequest : AbstractRequest<DeleteTopicAttributeByNameResponse>
    {
        /// <summary>
        /// name
        /// </summary>
        private string name;

        /// <summary>
        /// topic urn
        /// </summary>
        private string topicUrn;

        public string Name { get => name; set => name = value; }
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.DELETE;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(topicUrn))
            {
                throw new ArgumentException("topic urn is null");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.TOPICS)
                    .Append(Constants.URL_DELIMITER).Append(topicUrn)
                    .Append(Constants.URL_DELIMITER).Append(Constants.ATTRIBUTES)
                    .Append(Constants.URL_DELIMITER).Append(name);
            return sb.ToString();
        }
    }
}
