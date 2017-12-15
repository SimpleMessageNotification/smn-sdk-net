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
using Smn.Http;
using Smn.Response.Sms;
using Smn.Util;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// list sms msg report request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
    public class ListSmsMsgReportRequest : AbstractRequest<ListSmsMsgReportResponse>
    {
        /// <summary>
        /// start_time
        /// </summary>
        private string startTime;

        /// <summary>
        /// end_time
        /// </summary>
        private string endTime;

        /// <summary>
        /// sign_id
        /// </summary>
        private string signId;

        /// <summary>
        /// mobile
        /// </summary>
        private string mobile;

        /// <summary>
        /// status
        /// </summary>
        private int? status;

        /// <summary>
        /// offset
        /// </summary>
        private int offset = 0;

        /// <summary>
        /// limit
        /// </summary>
        private int limit = 100;

        [DataMember(Name = "start_time")]
        public string StartTime { get => startTime; set => startTime = value; }
        [DataMember(Name = "end_time")]
        public string EndTime { get => endTime; set => endTime = value; }
        [DataMember(Name = "sign_id")]
        public string SignId { get => signId; set => signId = value; }
        [DataMember(Name = "mobile")]
        public string Mobile { get => mobile; set => mobile = value; }
        [DataMember(Name = "status")]
        public int? Status { get => status; set => status = value; }
        [DataMember(Name = "offset")]
        public int Offset { get => offset; set => offset = value; }
        [DataMember(Name = "limit")]
        public int Limit { get => limit; set => limit = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.GET;
        }

        public override string GetUrl()
        {
            if (!ValidateUtil.ValidateOffset(offset))
            {
                throw new ArgumentException("offset is invalid");
            }

            if (!ValidateUtil.ValidateLimit(limit))
            {
                throw new ArgumentException("limit is invalid");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_SMS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMS_REPORT);

            String parameters = GetQueryParameters(this);
            if (!string.IsNullOrEmpty(parameters))
            {
                sb.Append("?").Append(parameters);
            }
            return sb.ToString();
        }
    }
}
