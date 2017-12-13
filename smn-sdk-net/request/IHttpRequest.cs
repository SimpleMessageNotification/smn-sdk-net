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
using System.Collections.Generic;
using System.Text;

namespace Smn.Request
{
    ///<summary> 
    /// interface request message 
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    interface IHttpRequest
    {
        /// <summary>
        /// get the request http method
        /// </summary>
        /// <returns>http method</returns>
        HttpMethod GetHttpMethod();

        /// <summary>
        /// get the request timeout
        /// </summary>
        /// <returns>timeout</returns>
        int? GetTimeout();

        /// <summary>
        /// get the url of the request
        /// </summary>
        /// <returns>url</returns>
        string GetUrl();

        /// <summary>
        /// get the body parms of the request
        /// </summary>
        /// <returns>body parms</returns>
        string GetBodyParams();

        /// <summary>
        /// get the request user agent info
        /// </summary>
        /// <returns>user agen</returns>
        string GetUserAgent();

        /// <summary>
        /// get the content type of the request
        /// </summary>
        /// <returns>content type</returns>
        string GetContentType();

        /// <summary>
        /// get the encoding of the request
        /// </summary>
        /// <returns>encoding</returns>
        Encoding GetRequestEncoding();

        /// <summary>
        /// get the headers of the request
        /// </summary>
        /// <returns>header</returns>
        IDictionary<string, string> GetHeaders();

        /// <summary>
        /// add header to request
        /// </summary>
        /// <param name="key">header key</param>
        /// <param name="value">header value</param>
        void AddHeader(string key, string value);

        /// <summary>
        /// set the project id of the request
        /// </summary>
        /// <param name="projectId">project id of current region</param>
        void SetProjectId(string projectId);
    }
}
