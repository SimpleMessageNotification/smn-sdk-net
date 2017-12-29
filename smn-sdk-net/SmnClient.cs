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
using Smn.Auth;
using Smn.Config;
using Smn.Request;
using Smn.Response;
using Smn.Http;
using System.Net;
using System;

namespace Smn
{
    ///<summary> 
    ///smn client
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class SmnClient
    {
        private SmnConfiguration smnConfiguration;
        private ClientConfiguration clientConfiguration;
        private IamAuth auth;

        /// <summary>
        /// create a new smn client instance
        /// </summary>
        /// <param name="username">you cloud username</param>
        /// <param name="domainName">you cloud domainName</param>
        /// <param name="password">you cloud password</param>
        /// <param name="regionName">region name, see http://developer.huaweicloud.com/endpoint.html</param>
        public SmnClient(string username, string domainName, string password, string regionName)
            : this(username, domainName, password, regionName, new ClientConfiguration()) { }

        /// <summary>
        /// create a new smn client instance with clientConfigurtaion
        /// </summary>
        /// <param name="username">you cloud username</param>
        /// <param name="domainName">you cloud domainName</param>
        /// <param name="password">you cloud password</param>
        /// <param name="regionName">region name, see http://developer.huaweicloud.com/endpoint.html</param>
        public SmnClient(string username, string domainName, string password, string regionName, ClientConfiguration clientConfiguration)
        {
            smnConfiguration = new SmnConfiguration
            {
                Username = username,
                DomainName = domainName,
                Password = password,
                RegionName = regionName
            };
            this.clientConfiguration = clientConfiguration ?? new ClientConfiguration();
            auth = new IamAuth
            {
                SmnConfiguration = smnConfiguration,
                ClientConfiguration = clientConfiguration
            };
        }

        /// <summary>
        ///  send the request
        /// </summary>
        /// <typeparam name="T">the response the request return</typeparam>
        /// <param name="httpRequest">the request you want to send</param>
        /// <returns></returns>
        public T SendRequest<T>(AbstractRequest<T> httpRequest) where T : BaseResponse
        {
            auth.GetTokenAndProjectId(out string projectId, out string authToken);
            AddCommonHeaders(httpRequest, authToken, projectId);
            httpRequest.SmnConfiguration = smnConfiguration;
            httpRequest.ProjectId = projectId;
            HttpWebResponse response = HttpTool.GetHttpResponse(httpRequest, this.clientConfiguration);
            return httpRequest.GetResponse(response);
        }

        private void AddCommonHeaders(IHttpRequest httpRequest, string token, string projectId)
        {
            if (string.IsNullOrEmpty(projectId))
            {
                throw new ArgumentException("project id is null");
            }
            httpRequest.AddHeader("region", smnConfiguration.RegionName);
            httpRequest.AddHeader("X-Auth-Token", token);
            httpRequest.AddHeader("X-Project-Id", projectId);
            httpRequest.AddHeader("X-Smn-Sdk", smnConfiguration.GetUserAgent());
        }
    }
}
