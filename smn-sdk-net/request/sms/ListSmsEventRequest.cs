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
    /// list sms event request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
    public class ListSmsEventRequest : AbstractRequest<ListSmsEventResponse>
    {
        /// <summary>
        /// event_type
        /// </summary>
        private string eventType;

        [DataMember(Name = "event_type")]
        public string EventType { get => eventType; set => eventType = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.GET;
        }

        public override string GetUrl()
        {
            if(!string.IsNullOrEmpty(eventType) && !ValidateUtil.ValidateSmsEventType(eventType))
            {
                throw new ArgumentException("event type is invalid");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_SMS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.CALLBACK);

            String parameters = GetQueryParameters(this);
            if (!string.IsNullOrEmpty(parameters))
            {
                sb.Append("?").Append(parameters);
            }
            return sb.ToString();
        }
    }
}
