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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Smn.Http;
using Smn.Response.Sms;
using Smn.Util;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// list sms template request message
    /// author:zhangyx
    /// version:1.0.1
    ///</summary> 
    public class ListSmsTemplatesRequest : AbstractRequest<ListSmsTemplatesResponse>
    {
        /// <summary>
        /// offset
        /// </summary>
        private int offset = 0;

        /// <summary>
        /// limit
        /// </summary>
        private int limit = 100;

        /// <summary>
        /// sms template name
        /// </summary>
        private string smsTemplateName;

        /// <summary>
        /// sms template type
        /// </summary>
        private int smsTemplateType;

        [JsonProperty("offset")]
        public int Offset { get => offset; set => offset = value; }
        [JsonProperty("limit")]
        public int Limit { get => limit; set => limit = value; }
        [JsonProperty("sms_template_name")]
        public string SmsTemplateName { get => smsTemplateName; set => smsTemplateName = value; }
        [JsonProperty("sms_template_type")]
        public int SmsTemplateType { get => smsTemplateType; set => smsTemplateType = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.GET;
        }

        public override string GetUrl()
        {
            if (!ValidateUtil.ValidateOffset(offset))
            {
                throw new ArgumentException("offset is invalid");
            }

            if (!ValidateUtil.ValidateLimit(limit))
            {
                throw new ArgumentException("limit is invalid");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SMS_TEMPLATE);

            String parameters = GetQueryParameters(this);
            if (!string.IsNullOrEmpty(parameters))
            {
                sb.Append("?").Append(parameters);
            }

            return sb.ToString();
        }
    }
}
