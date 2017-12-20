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
using System;

namespace Smn.Util
{
    ///<summary> 
    /// json parse util
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class JsonUtil
    {
        /// <summary>
        ///Serialize the object to JSON string
        /// </summary>
        /// <param name="item">object</param>
        /// <returns>JSON string</returns>
        public static string Serialize(object item)
        {
            try
            {
                return JsonConvert.SerializeObject(item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// UnSerialize JSON strings to object
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="jsonString">json string</param>
        /// <returns>the object</returns>
        public static T UnSerialize<T>(string jsonString)
        {
            T jsonObject = JsonConvert.DeserializeObject<T>(jsonString);
            return jsonObject;
        }
    }
}
