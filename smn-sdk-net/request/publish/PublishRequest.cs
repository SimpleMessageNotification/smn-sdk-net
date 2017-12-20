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
using Smn.Http;
using Smn.Response.Publish;
using Smn.Util;
using System;
using System.Text;

namespace Smn.Request.Publish
{
    ///<summary> 
    /// publish with message text request message
    /// Publish messages in common text to a topic. 
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class PublishRequest : AbstractRequest<PublishResponse>
    {
        /// <summary>
        /// topic urn
        /// </summary>
        private string topicUrn;

        /// <summary>
        /// subject 
        /// </summary>
        private string subject;

        /// <summary>
        /// message
        /// </summary>
        private string message;
        [JsonIgnore]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }
        [JsonProperty("subject")]
        public string Subject { get => subject; set => subject = value; }
        [JsonProperty("message")]
        public string Message { get => message; set => message = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(topicUrn))
            {
                throw new ArgumentException("topic urn is null");
            }

            if (!ValidateUtil.ValidateSubject(subject))
            {
                throw new ArgumentException("subject is invalid");
            }

            if (!ValidateUtil.ValidateMessage(message))
            {
                throw new ArgumentException("message is invalid");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.TOPICS)
                    .Append(Constants.URL_DELIMITER).Append(topicUrn)
                    .Append(Constants.URL_DELIMITER).Append(Constants.PUBLISH);
            return sb.ToString();
        }
    }
}
