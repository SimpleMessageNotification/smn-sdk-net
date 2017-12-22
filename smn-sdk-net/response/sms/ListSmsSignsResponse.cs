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

namespace Smn.Response.Sms
{
    ///<summary> 
    /// list sms signs response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class ListSmsSignsResponse : BaseResponse
    {
        /// <summary>
        /// sms_sign_count
        /// </summary>
        private int smsSignCount;

        /// <summary>
        /// sms_signs
        /// </summary>
        private List<SmsSignInfo> smsSigns;

        [JsonProperty("sms_sign_count")]
        public int SmsSignCount { get => smsSignCount; set => smsSignCount = value; }
        [JsonProperty("sms_signs")]
        public List<SmsSignInfo> SmsSigns { get => smsSigns; set => smsSigns = value; }
    }

    ///<summary> 
    /// sms sign info data
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class SmsSignInfo
    {
        /// <summary>
        /// sign_name
        /// </summary>
        private string signName;

        /// <summary>
        /// create_time
        /// </summary>
        private string createTime;

        /// <summary>
        /// sign_id
        /// </summary>
        private string signId;

        /// <summary>
        /// reply
        /// </summary>
        private string reply;

        /// <summary>
        /// status
        /// </summary>
        private int status;

        [JsonProperty("sign_name")]
        public string SignName { get => signName; set => signName = value; }
        [JsonProperty("create_time")]
        public string CreateTime { get => createTime; set => createTime = value; }
        [JsonProperty("sign_id")]
        public string SignId { get => signId; set => signId = value; }
        [JsonProperty("reply")]
        public string Reply { get => reply; set => reply = value; }
        [JsonProperty("status")]
        public int Status { get => status; set => status = value; }
    }
}
