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
using System;
using System.Text;
using Newtonsoft.Json;
using Smn.Http;
using Smn.Response.Subscription;
using Smn.Util;

namespace Smn.Request.Subscription
{
    ///<summary> 
    /// Subscribe request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class SubscribeRequest : AbstractRequest<SubscribeResponse>
    {
        /// <summary>
        /// topic urn
        /// </summary>
        private string topicUrn;

        /// <summary>
        /// protocol
        /// </summary>
        private string protocol;

        /// <summary>
        /// endpoint
        /// </summary>
        private string endpoint;

        /// <summary>
        /// remark
        /// </summary>
        private string remark;

        [JsonIgnore]
        public string TopicUrn { get => topicUrn; set => topicUrn = value; }
        [JsonProperty("protocol")]
        public string Protocol { get => protocol; set => protocol = value; }
        [JsonProperty("endpoint")]
        public string Endpoint { get => endpoint; set => endpoint = value; }
        [JsonProperty("remark")]
        public string Remark { get => remark; set => remark = value; }

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

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.TOPICS)
                    .Append(Constants.URL_DELIMITER).Append(topicUrn)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SUBSCRIPTIONS);
            return sb.ToString();
        }
    }
}
