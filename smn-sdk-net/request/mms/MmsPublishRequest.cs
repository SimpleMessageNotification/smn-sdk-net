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
using Smn.Response.Mms;
using System;
using System.Collections.Generic;
using Smn.Util;
using System.Text;

namespace Smn.Request.Mms
{
    ///<summary> 
    /// publish mms request message
    /// author:zhangyx
    /// version:1.0.4
    ///</summary> 
    public class MmsPublishRequest : AbstractRequest<MmsPublishResponse>
    {
        /// <summary>
        /// message access point
        /// </summary>
        private List<string> endpoints;

        /// <summary>
        /// title
        /// </summary>
        private string title;

        /// <summary>
        /// sms signature id
        /// </summary>
        private string signId;

        /// <summary>
        /// mms_message
        /// </summary>
        private List<MmsFrame> mmsMessage;

        [JsonProperty("endpoints")]
        public List<string> Endpoints { get => endpoints; set => endpoints = value; }
        [JsonProperty("title")]
        public string Title { get => title; set => title = value; }
        [JsonProperty("sign_id")]
        public string SignId { get => signId; set => signId = value; }
        [JsonProperty("mms_message")]
        public List<MmsFrame> MmsMessage { get => mmsMessage; set => mmsMessage = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title is null");
            }

            if (string.IsNullOrEmpty(signId))
            {
                throw new ArgumentException("sign id is null");
            }

            if (endpoints == null || endpoints.Count == 0)
            {
                throw new ArgumentException("endpoints is null or empty");
            }

            if (mmsMessage == null || mmsMessage.Count == 0)
            {
                throw new ArgumentException("mms_message is null or empty");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_MMS);
            return sb.ToString();
        }
    }

    ///<summary> 
    /// mms publish data frame
    /// author:zhangyx
    /// version:1.0.4
    ///</summary> 
    public class MmsFrame
    {
        private String text;
        private MmsFrameMessage image;
        private MmsFrameMessage voice;

        [JsonProperty("text")]
        public string Text { get => text; set => text = value; }
        [JsonProperty("image")]
        public MmsFrameMessage Image { get => image; set => image = value; }
        [JsonProperty("voice")]
        public MmsFrameMessage Voice { get => voice; set => voice = value; }
    }

    ///<summary> 
    /// mms publish message
    /// author:zhangyx
    /// version:1.0.4
    ///</summary> 
    public class MmsFrameMessage
    {
        private string fileType;
        private string contentBase64;

        [JsonProperty("file_type")]
        public string FileType { get => fileType; set => fileType = value; }
        [JsonProperty("content_base64")]
        public string ContentBase64 { get => contentBase64; set => contentBase64 = value; }
    }
}
