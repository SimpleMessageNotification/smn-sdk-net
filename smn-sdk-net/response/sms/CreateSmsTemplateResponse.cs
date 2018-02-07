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

namespace Smn.Response.Sms
{
    ///<summary> 
    /// create sms template response message
    /// author:zhangyx
    /// version:1.0.1
    ///</summary> 
    public class CreateSmsTemplateResponse : BaseResponse
    {
        /// <summary>
        /// sms template id
        /// </summary>
        private string smsTemplateId;

        [JsonProperty("sms_template_id")]
        public string SmsTemplateId { get => smsTemplateId; set => smsTemplateId = value; }
    }
}
