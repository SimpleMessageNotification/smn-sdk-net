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
using Smn.Http;
using Smn.Response.Template;
using Smn.Util;
using System;
using System.Text;

namespace Smn.Request.Template
{
    ///<summary> 
    /// create message template request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary>
    public class CreateMessageTemplateRequest : AbstractRequest<CreateMessageTemplateResponse>
    {
        /// <summary>
        /// message_template_name
        /// </summary>
        private string messageTemplateName;

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
        [JsonProperty("content")]
        public string Content { get => content; set => content = value; }
        [JsonProperty("protocol")]
        public string Protocol { get => protocol; set => protocol = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            if (!ValidateUtil.ValidateMessageTemplateName(messageTemplateName))
            {
                throw new ArgumentException("message template name is invalid");
            }

            if (!ValidateUtil.ValidateMessageTemplateContent(content))
            {
                throw new ArgumentException("content is invalid");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.MESSAGE_TEMPLATE);
            return sb.ToString();
        }
    }
}
