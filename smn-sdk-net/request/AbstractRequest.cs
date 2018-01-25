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
using System.Text;
using Smn.Config;
using Smn.Http;
using Smn.Util;
using System.Net;
using Smn.Response;
using System.Reflection;
using System;
using Newtonsoft.Json;

namespace Smn.Request
{
    ///<summary> 
    /// base abstract class for request
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public abstract class AbstractRequest<T> : IHttpRequest where T : BaseResponse
    {
        private SmnConfiguration smnConfiguration;
        private ClientConfiguration clientConfiguration;
        private string projectId;
        private Dictionary<string, string> headers;
        private int? timeout;

        [JsonIgnore]
        public SmnConfiguration SmnConfiguration { get => smnConfiguration; set => smnConfiguration = value; }
        [JsonIgnore]
        public string ProjectId { get => projectId; set => projectId = value; }
        [JsonIgnore]
        public Dictionary<string, string> Headers { get => headers; set => headers = value; }
        [JsonIgnore]
        public int? Timeout { get => timeout; set => timeout = value; }
        public ClientConfiguration ClientConfiguration { get => clientConfiguration; set => clientConfiguration = value; }

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
            if(clientConfiguration != null && !string.IsNullOrEmpty(clientConfiguration.SmnHostUrl))
            {
                return clientConfiguration.SmnHostUrl;
            }

            return Constants.HTTPS + Constants.SMN + "." + SmnConfiguration.RegionName + "." + Constants.ENDPOINT;
        }

        public string GetIamServiceUrl()
        {
            if (clientConfiguration != null && !string.IsNullOrEmpty(clientConfiguration.IamHostUrl))
            {
                return clientConfiguration.IamHostUrl;
            }
            return Constants.HTTPS + Constants.IAM + "." + SmnConfiguration.RegionName + "." + Constants.ENDPOINT;
        }

        public IDictionary<string, string> GetHeaders()
        {
            return headers;
        }

        public abstract HttpMethod GetHttpMethod();

        public abstract string GetUrl();

        /// <summary>
        /// User defined parameters, if not set back to null
        /// </summary>
        /// <returns>timeout</returns>
        public int? GetTimeout()
        {
            return timeout;
        }

        public virtual string GetBodyParams()
        {
            return JsonUtil.Serialize(this);
        }

        /// <summary>
        /// parse the response for the return value
        /// </summary>
        /// <param name="response">http response</param>
        /// <returns>the response object</returns>
        public virtual T GetResponse(HttpWebResponse response)
        {
            string responseMessage = HttpTool.GetStream(response, Encoding.UTF8);
            T smnResponse = JsonUtil.UnSerialize<T>(responseMessage);
            smnResponse.StatusCode = (int)response.StatusCode;
            smnResponse.ContentString = responseMessage;
            return smnResponse;
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

        /// <summary>
        /// obtain get method query Parameters
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>parameters</returns>
        public string GetQueryParameters(Object obj)
        {
            StringBuilder sb = new StringBuilder();
            Type t = obj.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();
                if (mi == null || !mi.IsPublic)
                {
                    continue;
                }

                object[] attributes = p.GetCustomAttributes(typeof(JsonPropertyAttribute), true);
                JsonPropertyAttribute jsonPropertyAttribute = null;
                if (attributes == null || attributes.Length == 0)
                {
                    continue;
                }
                foreach (object a in attributes)
                {
                    if (typeof(JsonPropertyAttribute) == a.GetType())
                    {
                        jsonPropertyAttribute = (JsonPropertyAttribute)a;
                    }
                }
                if (jsonPropertyAttribute == null)
                {
                    continue;
                }

                object value = mi.Invoke(obj, new Object[] { });
                if (value == null || string.IsNullOrEmpty(Convert.ToString(value)))
                {
                    continue;
                }

                sb.Append(jsonPropertyAttribute.PropertyName).Append("=").Append(Convert.ToString(value)).Append("&");
            }

            int strIndex = sb.Length;
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                sb.Remove(strIndex - 1, 1);
            }
            return sb.ToString();
        }
    }
}
