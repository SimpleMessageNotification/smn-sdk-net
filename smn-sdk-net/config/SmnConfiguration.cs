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
namespace Smn.Config
{
    ///<summary> 
    /// smn config 
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class SmnConfiguration
    {
        private string version = "1.0.4";
        private string username;
        private string domainName;
        private string password;
        private string regionName;

        public string Username { get => username; set => username = value; }
        public string DomainName { get => domainName; set => domainName = value; }
        public string Password { get => password; set => password = value; }
        public string RegionName { get => regionName; set => regionName = value; }

        /// <summary>
        /// return user agent
        /// </summary>
        /// <returns></returns>
        public string GetUserAgent()
        {
            return "smn-sdk-net/ " + version;
        }
    }
}
