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
using Newtonsoft.Json;

namespace Smn.Response.Template
{
    ///<summary> 
    /// create template message response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class CreateMessageTemplateResponse : BaseResponse
    {
        /// <summary>
        /// message_template_id
        /// </summary>
        private string messageTemplateId;

        [JsonProperty("message_template_id")]
        public string MessageTemplateId { get => messageTemplateId; set => messageTemplateId = value; }
    }
}
