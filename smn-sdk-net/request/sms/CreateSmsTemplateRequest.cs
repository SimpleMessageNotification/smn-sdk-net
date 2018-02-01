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
using System.Text;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// create sms template request message
    /// author:zhangyx
    /// version:1.0.1
    ///</summary> 
    public class CreateSmsTemplateRequest : AbstractRequest<CreateSmsTemplateResponse>
    {
        /// <summary>
        /// sms template name
        /// </summary>
        private string smsTemplateName;

        /// <summary>
        /// sms template content
        /// </summary>
        private string smsTemplateContent;

        /// <summary>
        /// remark
        /// </summary>
        private string remark;

        /// <summary>
        /// sms template type
        /// </summary>
        private int smsTemplateType;

        [JsonProperty("sms_template_name")]
        public string SmsTemplateName { get => smsTemplateName; set => smsTemplateName = value; }
        [JsonProperty("sms_template_content")]
        public string SmsTemplateContent { get => smsTemplateContent; set => smsTemplateContent = value; }
        [JsonProperty("remark")]
        public string Remark { get => remark; set => remark = value; }
        [JsonProperty("sms_template_type")]
        public int SmsTemplateType { get => smsTemplateType; set => smsTemplateType = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(smsTemplateContent))
            {
                throw new ArgumentException("sms template content is null");
            }

            if (string.IsNullOrEmpty(smsTemplateName))
            {
                throw new ArgumentException("sms template name is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SMS_TEMPLATE);
            return sb.ToString();
        }
    }
}
