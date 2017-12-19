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
using System.Text.RegularExpressions;

namespace Smn.Util
{
    ///<summary> 
    /// validate util
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    class ValidateUtil
    {
        private const string PATTERN_TELTPHONE = "^\\+?[0-9]{1,31}";
        private const string PATTERN_TOPIC_NAME = "^[a-zA-Z0-9]{1}[-_a-zA-Z0-9]{0,255}$";
        private const int MAX_DISPLAY_NAME_LENGTH = 192;

        /// <summary>
        /// validate phone
        /// </summary>
        /// <param name="phone">phone number</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidatePhone(string phone)
        {
            Regex rg_chk = new Regex(PATTERN_TELTPHONE);
            Match mt = rg_chk.Match(phone);
            return mt.Success;
        }

        /// <summary>
        /// validate offset
        /// </summary>
        /// <param name="offset">offset</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateOffset(int offset)
        {
            return offset >= 0;
        }

        /// <summary>
        /// validate limit
        /// </summary>
        /// <param name="limit">limit</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateLimit(int limit)
        {
            return limit > 0 && limit <= 100;
        }

        /// <summary>
        /// validate event type
        /// </summary>
        /// <param name="eventType">eventType</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateSmsEventType(string eventType)
        {
            return string.Equals(eventType, Constants.SMS_CALLBACK_SUCCESS)
                || string.Equals(eventType, Constants.SMS_CALLBACK_FAIL)
                || string.Equals(eventType, Constants.SMS_CALLBACK_REPLY);
        }

        /// <summary>
        /// validate topic name
        /// </summary>
        /// <param name="eventType">eventType</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateTopicName(string topicName)
        {
            if(string.IsNullOrEmpty(topicName))
            {
                return false;
            }
            Regex rg_chk = new Regex(PATTERN_TOPIC_NAME);
            Match mt = rg_chk.Match(topicName);
            return mt.Success;
        }

        /// <summary>
        /// validate topic name
        /// </summary>
        /// <param name="eventType">eventType</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateDisplayName(string displayName) 
        {
            byte[] byteArray = System.Text.Encoding.GetEncoding(Constants.UTF8).GetBytes(displayName);
            return byteArray.Length < MAX_DISPLAY_NAME_LENGTH;
        }
    }
}
