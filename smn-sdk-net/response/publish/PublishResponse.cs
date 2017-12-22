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

namespace Smn.Response.Publish
{
    ///<summary> 
    /// publish message response
    /// for PublishWithStrctureRequest/PublishRequest
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class PublishResponse : BaseResponse
    {
        /// <summary>
        /// message_id
        /// </summary>
        private string messageId;

        [JsonProperty("message_id")]
        public string MessageId { get => messageId; set => messageId = value; }
    }
}
