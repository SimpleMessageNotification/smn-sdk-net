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
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// get sms message request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
    public class GetSmsMessageRequest : AbstractRequest<GetSmsMessageResponse>
    {
        /// <summary>
        /// message_id
        /// </summary>
        private string messageId;

        [DataMember(Name = "message_id")]
        public string MessageId { get => messageId; set => messageId = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.GET;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(messageId))
            {
                throw new ArgumentException("message id is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SUB_PROTOCOL_SMS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMS_MESSAGE)
                    .Append(Constants.URL_DELIMITER).Append(messageId);
            return sb.ToString();
        }

        /// <summary>
        /// the normal return message field conflicts with the message field int the error message 
        /// so rewite the method
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public override GetSmsMessageResponse GetResponse(HttpWebResponse response)
        {
            string responseMessage = HttpTool.GetStream(response, Encoding.UTF8);
            GetSmsMessageResponse smnResponse = JsonUtil.UnSerialize<GetSmsMessageResponse>(responseMessage);
            smnResponse.StatusCode = (int)response.StatusCode;
            smnResponse.ContentString = responseMessage;
            if(smnResponse.IsSuccess())
            {
                smnResponse.Message = smnResponse.ErrMessage;
                smnResponse.ErrMessage = "";
            }
            return smnResponse;
        }
    }
}
