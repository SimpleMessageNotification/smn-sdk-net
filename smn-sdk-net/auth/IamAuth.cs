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
using Smn.Request;
using System.Net;
using System.Text;
using Smn.Util;
using System.Collections.Generic;
using System;
using Smn.Config;

namespace Smn.Auth
{
    ///<summary> 
    /// used for user authentication 
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    class IamAuth
    {
        private SmnConfiguration smnConfiguration;
        private string projectId;
        private string authToken;
        private long expiresTime;
        private string expirtAt;

        private const int EXPIRED_INTERVAL = 30 * 60 * 1000;

        public string ProjectId { get => projectId; set => projectId = value; }
        public string AuthToken { get => authToken; set => authToken = value; }
        public long ExpiresTime { get => expiresTime; set => expiresTime = value; }
        public SmnConfiguration SmnConfiguration { get => smnConfiguration; set => smnConfiguration = value; }


        /// <summary>
        /// locker
        /// </summary>
        private static readonly object locker = new object();


        /// <summary>
        /// get user projectId and token
        /// </summary>
        /// <param name="project">project for region</param>
        /// <param name="token">user token</param>
        public void GetTokenAndProjectId(out string project, out string token)
        {
            if (string.IsNullOrEmpty(authToken) || IsExpired())
            {
                lock (locker)
                {
                    if (string.IsNullOrEmpty(authToken) || IsExpired())
                    {
                        PostForIamToken();
                    }
                }
            }

            project = projectId;
            token = authToken;
        }

        private void PostForIamToken()
        {
            IamRequest request = new IamRequest();
            request.SmnConfiguration = smnConfiguration;
            HttpWebResponse response = HttpTool.GetHttpResponse(request);

            string responseMessage = HttpTool.GetStream(response, Encoding.UTF8);

            if (!HttpTool.IsSuccess(response))
            {
                throw new SystemException("Unexpected response status: " + response.StatusCode + ", ErrorMessage is " + responseMessage);
            }

            authToken = response.Headers.Get(Constants.X_SUBJECT_TOKEN);
            Dictionary<string, object> map = JsonUtil.JsonToDictionary(responseMessage);
            projectId = ((Dictionary<string, object>)((Dictionary<string, object>)map[Constants.TOKEN])[Constants.PROJECT])[Constants.ID].ToString();
            expirtAt = ((Dictionary<string, object>)map[Constants.TOKEN])[Constants.EXPIRES_AT].ToString();

            expiresTime = DateUtil.GetTimeStamp(DateUtil.ConvertToDateTimeUtc(expirtAt)) - EXPIRED_INTERVAL;
        }

        private bool IsExpired()
        {
            return expiresTime < DateUtil.GetTimeStamp(DateTime.Now);
        }
    }
}
