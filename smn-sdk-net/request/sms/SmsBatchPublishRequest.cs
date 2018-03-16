/*
 * Copyright (C) 2018. Huawei Technologies Co., LTD. All rights reserved.
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
using Smn.Response.Sms;
using Smn.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// batch publish notifications and verify sms request message
    /// author:zhangyx
    /// version:1.0.2
    ///</summary> 
    public class SmsBatchPublishRequest : AbstractRequest<SmsBatchPublishResponse>
    {
        /// <summary>
        /// message access point
        /// </summary>
        private List<string> endpoints;

        /// <summary>
        /// message content
        /// </summary>
        private String message;

        /// <summary>
        /// sms signature id
        /// </summary>
        private string signId;

        [JsonProperty("endpoints")]
        public List<string> Endpoints { get => endpoints; set => endpoints = value; }
        [JsonProperty("sign_id")]
        public string SignId { get => signId; set => signId = value; }
        [JsonProperty("message")]
        public string Message { get => message; set => message = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(signId))
            {
                throw new ArgumentException("sign id is null");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("message is empty");
            }

            if (endpoints == null || endpoints.Count == 0)
            {
                throw new ArgumentException("endpoints is null or empty");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_SMS);
            return sb.ToString();
        }
    }
}
