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
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

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
        /// Deserialize the JSON data into Dictionary
        /// </summary>
        /// <param name="jsonData">json data</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///Serialize the object to JSON string
        /// </summary>
        /// <param name="item">object</param>
        /// <returns>JSON string</returns>
        public static string Serialize(object item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, item);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                    return sb.ToString();
                }
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
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                T jsonObject = (T)ser.ReadObject(ms);
                return jsonObject;
            }
        }
    }
}
