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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smn.Config
{

    /// <summary>
    /// http client smn config
    /// author:zhangyx
    /// version:1.0.0
    /// </summary>
    public class ClientConfiguration
    {
        /// <summary>
        /// proxy username
        /// </summary>
        private string proxyUsername;

        /// <summary>
        /// proxy password
        /// </summary>
        private string proxyPassword;

        /// <summary>
        /// proxy domain
        /// </summary>
        private string proxyDomain;

        /// <summary>
        /// proxy host
        /// </summary>
        private string proxyHost;

        /// <summary>
        /// proxy port
        /// </summary>
        private int? proxyPort;

        /// <summary>
        /// readwritetimeout and connection timeout
        /// </summary>
        private int? timeout;

        public string ProxyUsername { get => proxyUsername; set => proxyUsername = value; }
        public string ProxyPassword { get => proxyPassword; set => proxyPassword = value; }
        public string ProxyDomain { get => proxyDomain; set => proxyDomain = value; }
        public string ProxyHost { get => proxyHost; set => proxyHost = value; }
        public int? ProxyPort { get => proxyPort; set => proxyPort = value; }
        public int? Timeout { get => timeout; set => timeout = value; }
    }
}
