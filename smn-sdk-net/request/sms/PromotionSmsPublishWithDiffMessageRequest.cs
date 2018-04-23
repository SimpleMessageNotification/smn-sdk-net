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
using System.Linq;
using System.Text;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// promotion smn batch publish with diff message request
    /// author:zhangyx
    /// version:1.0.4
    ///</summary> 
    public class PromotionSmsPublishWithDiffMessageRequest : AbstractRequest<PromotionSmsPublishWithDiffMessageResponse>
    {
        /// <summary>
        /// sms_message
        /// </summary>
        private List<PromotionSmsPublishMessage> smsMessages;

        [JsonProperty("sms_message")]
        public List<PromotionSmsPublishMessage> SmsMessages { get => smsMessages; set => smsMessages = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_SMS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SMS_PROMOTION);
            return sb.ToString();
        }
    }

    /// <summary>
    /// the message data for PromotionSmsPublishWithDiffMessageRequest
    /// </summary>
    public class PromotionSmsPublishMessage
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
    }
}
