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
using System;
using System.Text;
using Smn.Util;
using Smn.Response.Sms;
using Newtonsoft.Json;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// smn publish request message
    /// Directly send SMS messages to phone numbers, 
    /// usually used for verification code or notification.
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class SmsPublishRequest : AbstractRequest<SmsPublishResponse>
    {
        /// <summary>
        /// message access point
        /// </summary>
        private string endpoint;

        /// <summary>
        /// message to send
        /// </summary>
        private string message;

        /// <summary>
        /// message signature id
        /// </summary>
        private string signId;

        /// <summary>
        /// message content contain sign flag
        /// </summary>
        private bool messageIncludeSignFlag = false;

        /// <summary>
        /// extend_code
        /// </summary>
        private string extendCode;

        /// <summary>
        /// extend_src_id
        /// </summary>
        private string extendSrcId;

        [JsonProperty("endpoint")]
        public string Endpoint { get => endpoint; set => endpoint = value; }
        [JsonProperty("message")]
        public string Message { get => message; set => message = value; }
        [JsonProperty("sign_id")]
        public string SignId { get => signId; set => signId = value; }
        [JsonProperty("message_include_sign_flag")]
        public bool MessageIncludeSignFlag { get => messageIncludeSignFlag; set => messageIncludeSignFlag = value; }
        [JsonProperty("extend_code")]
        public string ExtendCode { get => extendCode; set => extendCode = value; }
        [JsonProperty("extend_src_id")]
        public string ExtendSrcId { get => extendSrcId; set => extendSrcId = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("message is null");
            }

            if (!messageIncludeSignFlag && string.IsNullOrEmpty(signId))
            {
                throw new ArgumentException("signId is null");
            }

            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("endpoint is null or invalid");
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
