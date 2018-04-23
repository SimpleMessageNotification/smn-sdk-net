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
    /// promotion smn publish request message
    /// author:zhangyx
    /// version:1.0.1
    ///</summary> 
    public class PromotionSmsPublishRequest : AbstractRequest<PromotionSmsPublishResponse>
    {
        /// <summary>
        /// message access point
        /// </summary>
        private List<string> endpoints;

        /// <summary>
        /// sms template id
        /// </summary>
        private String smsTemplateId;

        /// <summary>
        /// sms signature id
        /// </summary>
        private string signId;

        /// <summary>
        /// extend_code
        /// </summary>
        private string extendCode;

        /// <summary>
        /// extend_src_id
        /// </summary>
        private string extendSrcId;

        [JsonProperty("endpoints")]
        public List<string> Endpoints { get => endpoints; set => endpoints = value; }
        [JsonProperty("sms_template_id")]
        public string SmsTemplateId { get => smsTemplateId; set => smsTemplateId = value; }
        [JsonProperty("sign_id")]
        public string SignId { get => signId; set => signId = value; }
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
            if (string.IsNullOrEmpty(signId))
            {
                throw new ArgumentException("sign id is null");
            }

            if (string.IsNullOrEmpty(smsTemplateId))
            {
                throw new ArgumentException("sms template id is null");
            }

            if (endpoints == null || endpoints.Count == 0)
            {
                throw new ArgumentException("endpoints is null or empty");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_SMS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SMS_PROMOTION);
            return sb.ToString();
        }
    }
}
