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
using Smn.Response.Sms;
using Smn.Util;
using System;
using System.Text;

namespace Smn.Request.Sms
{
    ///<summary> 
    /// delete sms sign request message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class DeleteSmsSignRequest : AbstractRequest<DeleteSmsSignResponse>
    {
        /// <summary>
        /// sign id
        /// </summary>
        private string signId;

        [JsonProperty("sign_id")]
        public string SignId { get => signId; set => signId = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.DELETE;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(signId))
            {
                throw new ArgumentException("sign id is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SMN_SIGN).Append(Constants.URL_DELIMITER)
                    .Append(signId);
            return sb.ToString();
        }
    }
}
