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
using System.Globalization;

namespace Smn.Util
{
    ///<summary> 
    /// data util
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    class DateUtil
    {

        /// <summary>
        /// convert date string to datetime by utc zone
        /// </summary>
        /// <param name="dateString">date string</param>
        /// <returns>datetime</returns>
        public static DateTime ConvertToDateTimeUtc(string dateString)
        {
            return DateTime.ParseExact(Convert.ToDateTime(dateString).ToString("o"), "o", CultureInfo.InvariantCulture,
                             DateTimeStyles.None);
        }

        /// <summary>
        /// get time stamp
        /// </summary>
        /// <param name="time">date time</param>
        /// <returns>time stamp</returns>
        public static long GetTimeStamp(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));  
            return (long)(time - startTime).TotalMilliseconds;  
        }
    }
}
