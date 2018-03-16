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
using System.Collections.Generic;

namespace Smn.Response.Sms
{
    ///<summary> 
    /// batch publish notifications and verify SMS response
    /// author:zhangyx
    /// version:1.0.2
    ///</summary> 
    public class SmsBatchPublishResponse : BaseResponse
    {
        /// <summary>
        /// result
        /// </summary>
        private List<SmsBatchPublishResult> result;

        [JsonProperty("result")]
        public List<SmsBatchPublishResult> Result { get => result; set => result = value; }
    }

    ///<summary> 
    /// batch publish notifications and verify SMS result
    /// author:zhangyx
    /// version:1.0.2
    ///</summary> 
    public class SmsBatchPublishResult
    {
        /// <summary>
        /// message id
        /// </summary>
        private string messageId;

        /// <summary>
        /// endpoint
        /// </summary>
        private string endpoint;

        /// <summary>
        /// code
        /// </summary>
        private string code;

        /// <summary>
        /// message
        /// </summary>
        private string message;

        [JsonProperty("message_id")]
        public string MessageId { get => messageId; set => messageId = value; }
        [JsonProperty("endpoint")]
        public string Endpoint { get => endpoint; set => endpoint = value; }
        [JsonProperty("code")]
        public string Code { get => code; set => code = value; }
        [JsonProperty("message")]
        public string Message { get => message; set => message = value; }
    }
}
