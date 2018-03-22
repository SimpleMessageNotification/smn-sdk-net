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
using System.Collections.Generic;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// smn batch publish with diff message request
    /// author:zhangyx
    /// version:1.0.3
    ///</summary> 
    public class SmsBatchPublishWithDiffMessageRequest : AbstractRequest<SmsBatchPublishWithDiffMessageResponse>
    {
        /// <summary>
        /// sms_message
        /// </summary>
        private List<SmsPublishMessage> smsMessages;

        [JsonProperty("sms_message")]
        public List<SmsPublishMessage> SmsMessages { get => smsMessages; set => smsMessages = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            if (smsMessages == null || smsMessages.Count == 0)
            {
                throw new ArgumentException("smsMessages is empty");
            }

            if(smsMessages.Count > ValidateUtil.MAX_SMS_BATCH_PUBLISH_SIZE)
            {
                throw new ArgumentException("smsMessages size must be less than 1000");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_BATCH_SMS);
            return sb.ToString();
        }
    }

    /// <summary>
    /// the message data for SmsBatchPublishWithDiffMessageRequest
    /// </summary>
    public class SmsPublishMessage
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

        /// <summary>
        /// message content contain sign flag
        /// </summary>
        private bool messageIncludeSignFlag = false;

        [JsonProperty("endpoint")]
        public string Endpoint { get => endpoint; set => endpoint = value; }
        [JsonProperty("message")]
        public string Message { get => message; set => message = value; }
        [JsonProperty("sign_id")]
        public string SignId { get => signId; set => signId = value; }
        [JsonProperty("message_include_sign_flag")]
        public bool MessageIncludeSignFlag { get => messageIncludeSignFlag; set => messageIncludeSignFlag = value; }
    }
}
