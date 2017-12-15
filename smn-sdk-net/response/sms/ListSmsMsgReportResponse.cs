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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Smn.Response.Sms
{
    ///<summary> 
    /// list sms msg report response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
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

        [DataMember(Name = "data")]
        public List<SmsReportData> Data { get => data; set => data = value; }
        [DataMember(Name = "count")]
        public int Count { get => count; set => count = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
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

        [DataMember(Name = "message_id")]
        public string MessageId { get => messageId; set => messageId = value; }
        [DataMember(Name = "status")]
        public int Status { get => status; set => status = value; }
        [DataMember(Name = "sign_id")]
        public string SignId { get => signId; set => signId = value; }
        [DataMember(Name = "status_desc")]
        public string StatusDesc { get => statusDesc; set => statusDesc = value; }
        [DataMember(Name = "fee_num")]
        public int FeeNum { get => feeNum; set => feeNum = value; }
        [DataMember(Name = "extend_code")]
        public string ExtendCode { get => extendCode; set => extendCode = value; }
        [DataMember(Name = "nation_code")]
        public string NationCode { get => nationCode; set => nationCode = value; }
        [DataMember(Name = "mobile")]
        public string Mobile { get => mobile; set => mobile = value; }
        [DataMember(Name = "submit_time")]
        public string SubmitTime { get => submitTime; set => submitTime = value; }
        [DataMember(Name = "deliver_time")]
        public string DeliverTime { get => deliverTime; set => deliverTime = value; }
    }
}
