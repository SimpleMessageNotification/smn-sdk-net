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
using System.Runtime.Serialization;
using Smn.Response.Sms;
using System.Net;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// smn publish request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
    public class SmsPublishRequest : AbstractRequest<SmsPublishResponse>
    {

        /// <summary>
        /// message access point
        /// </summary>
        private String endpoint;


        /// <summary>
        /// message to send
        /// </summary>
        private String message;


        /// <summary>
        /// message signature id
        /// </summary>
        private String signId;

        [DataMember(Name = "endpoint")]
        public string Endpoint { get => endpoint; set => endpoint = value; }
        [DataMember(Name = "message")]
        public string Message { get => message; set => message = value; }
        [DataMember(Name = "sign_id")]
        public string SignId { get => signId; set => signId = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override int? GetTimeout()
        {
            return null;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(signId))
            {
                throw new ArgumentException("sign id is null");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("message is null");
            }

            if (string.IsNullOrEmpty(endpoint) || !ValidateUtil.ValidatePhone(endpoint))
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
