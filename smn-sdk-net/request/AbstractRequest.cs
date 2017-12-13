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
using System.Text;
using Smn.Config;
using Smn.Http;
using Smn.Util;
using System.Net;
using Smn.Response;

namespace Smn.Request
{
    ///<summary> 
    /// base abstract class for request
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [DataContract]
    public abstract class AbstractRequest<T> : IHttpRequest where T: BaseResponse
    {
        private SmnConfiguration smnConfiguration;
        private string projectId;
        private Dictionary<string, string> headers;

        public SmnConfiguration SmnConfiguration { get => smnConfiguration; set => smnConfiguration = value; }
        public string ProjectId { get => projectId; set => projectId = value; }
        public Dictionary<string, string> Headers { get => headers; set => headers = value; }

        public Encoding GetRequestEncoding()
        {
            return Encoding.UTF8;
        }

        public string GetContentType()
        {
            return "application/json;charset=UTF-8";
        }

        public string GetUserAgent()
        {
            return SmnConfiguration.GetUserAgent();
        }

        public string GetSmnServiceUrl()
        {
            return Constants.HTTPS + Constants.SMN + "." + SmnConfiguration.RegionName + "." + Constants.ENDPOINT;

        }
        public IDictionary<string, string> GetHeaders()
        {
            return headers;
        }

        public abstract HttpMethod GetHttpMethod();

        public abstract int? GetTimeout();

        public abstract string GetUrl();

        public virtual string GetBodyParams()
        {
            return JsonUtil.Serialize(this);
        }

        //public abstract T GetResponse(HttpWebResponse response);
        public  T GetResponse(HttpWebResponse response)
        {
            string responseMessage = HttpTool.GetStream(response, Encoding.UTF8);
            T smsPublishResponse = JsonUtil.UnSerialize<T>(responseMessage);
            smsPublishResponse.StatusCode = (int)response.StatusCode;
            smsPublishResponse.ContentString = responseMessage;
            return smsPublishResponse;
        }

        public void AddHeader(string key, string value)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();

            }
            headers.Add(key, value);
        }

        public void SetProjectId(string projectId)
        {
            this.projectId = projectId;
        }
    }
}
