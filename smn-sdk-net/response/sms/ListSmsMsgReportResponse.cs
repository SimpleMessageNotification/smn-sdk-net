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
    /// list sms msg report response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class ListSmsMsgReportResponse : BaseResponse
    {
        /// <summary>
        /// count
        /// </summary>
        private int count;

        /// <summary>
        /// data
        /// </summary>
        private List<SmsReportData> data;

        [JsonProperty("data")]
        public List<SmsReportData> Data { get => data; set => data = value; }
        [JsonProperty("count")]
        public int Count { get => count; set => count = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SmsReportData
    {
        /// <summary>
        /// message_id
        /// </summary>
        private string messageId;

        /// <summary>
        /// status
        /// </summary>
        private int status;

        /// <summary>
        /// sign_id
        /// </summary>
        private string signId;

        /// <summary>
        /// status_desc
        /// </summary>
        private string statusDesc;

        /// <summary>
        /// fee_num
        /// </summary>
        private int feeNum;

        /// <summary>
        /// extend_code
        /// </summary>
        private string extendCode;

        /// <summary>
        /// nation_code
        /// </summary>
        private string nationCode;

        /// <summary>
        /// mobile
        /// </summary>
        private string mobile;

        /// <summary>
        /// submit_time
        /// </summary>
        private string submitTime;

        /// <summary>
        /// deliver_time
        /// </summary>
        private string deliverTime;

        [JsonProperty("message_id")]
        public string MessageId { get => messageId; set => messageId = value; }
        [JsonProperty("status")]
        public int Status { get => status; set => status = value; }
        [JsonProperty("sign_id")]
        public string SignId { get => signId; set => signId = value; }
        [JsonProperty("status_desc")]
        public string StatusDesc { get => statusDesc; set => statusDesc = value; }
        [JsonProperty("fee_num")]
        public int FeeNum { get => feeNum; set => feeNum = value; }
        [JsonProperty("extend_code")]
        public string ExtendCode { get => extendCode; set => extendCode = value; }
        [JsonProperty("nation_code")]
        public string NationCode { get => nationCode; set => nationCode = value; }
        [JsonProperty("mobile")]
        public string Mobile { get => mobile; set => mobile = value; }
        [JsonProperty("submit_time")]
        public string SubmitTime { get => submitTime; set => submitTime = value; }
        [JsonProperty("deliver_time")]
        public string DeliverTime { get => deliverTime; set => deliverTime = value; }
    }
}
