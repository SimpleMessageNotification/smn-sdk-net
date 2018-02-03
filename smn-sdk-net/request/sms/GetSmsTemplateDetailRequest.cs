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
    /// get sms template detail request message
    /// author:zhangyx
    /// version:1.0.1
    ///</summary> 
    public class GetSmsTemplateDetailRequest : AbstractRequest<GetSmsTemplateDetailResponse>
    {
        /// <summary>
        /// sms template id
        /// </summary>
        private String smsTemplateId;

        [JsonProperty("sms_template_id")]
        public string SmsTemplateId { get => smsTemplateId; set => smsTemplateId = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.GET;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(smsTemplateId))
            {
                throw new ArgumentException("sms template id is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SMS_TEMPLATE)
                    .Append(Constants.URL_DELIMITER).Append(smsTemplateId);
            return sb.ToString();
        }
    }
}
