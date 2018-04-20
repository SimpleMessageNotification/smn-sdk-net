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
using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Smn.Request;
using System.Text;
using Smn.Config;

namespace Smn.Http
{
    ///<summary> 
    /// smn http client tool
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    class HttpTool
    {
        /// <summary>
        /// send httpRequest and get response
        /// </summary>
        /// <param name="httpRequest">the request data to send</param>
        /// <param name="clientConfiguration">http client configuration</param>
        /// <returns>the response of the request</returns>
        public static HttpWebResponse GetHttpResponse(IHttpRequest httpRequest, ClientConfiguration clientConfiguration)
        {
            string url = httpRequest.GetUrl();
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url is null");
            }

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            HttpMethod httpMethod = httpRequest.GetHttpMethod();
            request.Method = httpMethod.ToString();
            request.ContentType = httpRequest.GetContentType();
            request.UserAgent = httpRequest.GetUserAgent();

            //set http proxy
            SetHttpProxy(request, clientConfiguration);
            // set timeout
            if (httpRequest.GetTimeout().HasValue)
            {
                request.Timeout = httpRequest.GetTimeout().Value;
                request.ReadWriteTimeout = httpRequest.GetTimeout().Value;
            }
            else if (clientConfiguration.Timeout.HasValue)
            {
                request.Timeout = clientConfiguration.Timeout.Value;
                request.ReadWriteTimeout = clientConfiguration.Timeout.Value;
            }

            #region add header
            if (!(httpRequest.GetHeaders() == null || httpRequest.GetHeaders().Count == 0))
            {
                foreach (string key in httpRequest.GetHeaders().Keys)
                {
                    request.Headers.Add(key, httpRequest.GetHeaders()[key]);
                }
            }
            #endregion add header

            #region post json
            if (httpMethod == HttpMethod.POST || httpMethod == HttpMethod.PUT)
            {
                string bodyParams = httpRequest.GetBodyParams();
                if (!string.IsNullOrEmpty(bodyParams))
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(bodyParams);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
            }
            #endregion post json

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebResponse = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    httpWebResponse = (HttpWebResponse)ex.Response;
                }
                else
                {
                    throw ex;
                }
            }

            return httpWebResponse;
        }

        /// <summary>
        /// Set the HTTPS certificate check mechanism, default back to True, verify through
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns>true</returns>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //Always accept
        }

        /// <summary>
        /// Judge whether the request is successful or not
        /// </summary>
        /// <param name="response">repsonse</param>
        /// <returns>if success return true, else return false</returns>
        public static bool IsSuccess(HttpWebResponse response)
        {
            int status = (int)response.StatusCode;
            if (200 <= status && status < 300)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// parse response body to string
        /// </summary>
        /// <param name="response">response</param>
        /// <param name="encoding">charset encoding, default utf8</param>
        /// <returns>body string</returns>
        public static string GetStream(HttpWebResponse response, Encoding encoding)
        {
            try
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
                {
                    string result = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    response.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// judge whether the request is no permission
        /// </summary>
        /// <param name="response"response>response</param>
        /// <returns></returns>
        public static bool IsNoPermission(HttpWebResponse response)
        {
            return 403 == (int)response.StatusCode || 401 == (int)response.StatusCode;
        }

        private static void SetHttpProxy(HttpWebRequest request, ClientConfiguration clientConfiguration)
        {
            request.Proxy = null;

            if (!string.IsNullOrEmpty(clientConfiguration.ProxyHost))
            {
                if (clientConfiguration.ProxyPort.HasValue)
                {

                    request.Proxy = new WebProxy(clientConfiguration.ProxyHost, clientConfiguration.ProxyPort.Value);
                }
                else
                {
                    request.Proxy = new WebProxy(clientConfiguration.ProxyHost);

                }

                if (!string.IsNullOrEmpty(clientConfiguration.ProxyUsername))
                {
                    request.Proxy.Credentials = String.IsNullOrEmpty(clientConfiguration.ProxyDomain) ?
                        new NetworkCredential(clientConfiguration.ProxyUsername, clientConfiguration.ProxyPassword ?? string.Empty) :
                        new NetworkCredential(clientConfiguration.ProxyUsername, clientConfiguration.ProxyPassword ?? string.Empty,
                                              clientConfiguration.ProxyDomain);
                }
            }
        }
    }
}
