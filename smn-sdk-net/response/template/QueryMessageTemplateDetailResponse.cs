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
using System.Collections.Generic;

namespace Smn.Response.Template
{
    ///<summary> 
    /// query message template detail response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class QueryMessageTemplateDetailResponse : BaseResponse
    {
        /// <summary>
        /// message_template_name
        /// </summary>
        private string messageTemplateName;

        /// <summary>
        /// create_time
        /// </summary>
        private string createTime;

        /// <summary>
        /// update_time
        /// </summary>
        private string updateTime;

        /// <summary>
        /// message_template_id
        /// </summary>
        private string messageTemplateId;

        /// <summary>
        /// tag_names
        /// </summary>
        private List<string> tagNames;

        /// <summary>
        /// content
        /// </summary>
        private string content;

        /// <summary>
        /// protocol
        /// </summary>
        private string protocol;

        [JsonProperty("message_template_name")]
        public string MessageTemplateName { get => messageTemplateName; set => messageTemplateName = value; }
        [JsonProperty("create_time")]
        public string CreateTime { get => createTime; set => createTime = value; }
        [JsonProperty("update_time")]
        public string UpdateTime { get => updateTime; set => updateTime = value; }
        [JsonProperty("message_template_id")]
        public string MessageTemplateId { get => messageTemplateId; set => messageTemplateId = value; }
        [JsonProperty("tag_names")]
        public List<string> TagNames { get => tagNames; set => tagNames = value; }
        [JsonProperty("content")]
        public string Content { get => content; set => content = value; }
        [JsonProperty("protocol")]
        public string Protocol { get => protocol; set => protocol = value; }
    }
}
