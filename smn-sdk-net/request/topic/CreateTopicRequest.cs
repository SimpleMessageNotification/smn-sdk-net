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
using Smn.Response.Topic;
using Smn.Util;
using System;
using System.Text;

namespace Smn.Request.Topic
{
    ///<summary> 
    /// create topic request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class CreateTopicRequest : AbstractRequest<CreateTopicResponse>
    {
        /// <summary>
        /// name
        /// </summary>
        private string name;

        /// <summary>
        /// display name
        /// </summary>
        private string displayName;

        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("display_name")]
        public string DisplayName { get => displayName; set => displayName = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            if (!ValidateUtil.ValidateTopicName(name))
            {
                throw new ArgumentException("name is invalid");
            }

            if (!string.IsNullOrEmpty(displayName) && !ValidateUtil.ValidateDisplayName(displayName))
            {
                throw new ArgumentException("display name is invalid");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.TOPICS);
            return sb.ToString();
        }
    }
}
