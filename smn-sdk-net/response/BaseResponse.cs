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

namespace Smn.Response
{
    ///<summary> 
    /// base response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class BaseResponse
    {
        private string requestId;
        private string errMessage;
        private string errCode;
        private int statusCode;
        private string contentString;

        [JsonProperty("request_id")]
        public string RequestId { get => requestId; set => requestId = value; }
        public int StatusCode { get => statusCode; set => statusCode = value; }
        public string ContentString { get => contentString; set => contentString = value; }
        [JsonProperty("message")]
        public string ErrMessage { get => errMessage; set => errMessage = value; }
        [JsonProperty("code")]
        public string ErrCode { get => errCode; set => errCode = value; }

        /// <summary>
        /// Judge whether the request is successful or not
        /// </summary>
        /// <param name="response">repsonse</param>
        /// <returns>if success return true, else return false</returns>
        public bool IsSuccess()
        {
            if (200 <= StatusCode && StatusCode < 300)
            {
                return true;
            }
            return false;
        }
    }
}
