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
using System;

namespace Smn.Response.Sms
{
    ///<summary> 
    /// get sms template detail response message
    /// author:zhangyx
    /// version:1.0.1
    ///</summary> 
    public class GetSmsTemplateDetailResponse : BaseResponse
    {
        /// <summary>
        /// sms template name
        /// </summary>
        private String smsTemplateName;

        /// <summary>
        /// sms template type
        /// </summary>
        private int smsTemplateType;

        /// <summary>
        /// sms template content
        /// </summary>
        private String smsTemplateContent;

        /// <summary>
        /// sms template id
        /// </summary>
        private String smsTemplateId;

        /// <summary>
        /// reply
        /// </summary>
        private String reply;

        /// <summary>
        /// status
        /// </summary>
        private int status;

        /// <summary>
        /// create time
        /// </summary>
        private String createTime;

        /// <summary>
        /// validity end time
        /// </summary>
        private String validityEndTime;

        [JsonProperty("sms_template_name")]
        public string SmsTemplateName { get => smsTemplateName; set => smsTemplateName = value; }
        [JsonProperty("sms_template_type")]
        public int SmsTemplateType { get => smsTemplateType; set => smsTemplateType = value; }
        [JsonProperty("sms_template_content")]
        public string SmsTemplateContent { get => smsTemplateContent; set => smsTemplateContent = value; }
        [JsonProperty("sms_template_id")]
        public string SmsTemplateId { get => smsTemplateId; set => smsTemplateId = value; }
        [JsonProperty("reply")]
        public string Reply { get => reply; set => reply = value; }
        [JsonProperty("status")]
        public int Status { get => status; set => status = value; }
        [JsonProperty("create_time")]
        public string CreateTime { get => createTime; set => createTime = value; }
        [JsonProperty("validity_end_time")]
        public string ValidityEndTime { get => validityEndTime; set => validityEndTime = value; }
    }
}
