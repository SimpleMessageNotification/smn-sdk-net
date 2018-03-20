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
        private static Regex PATTERN_TELTPHONE = new Regex("^\\+?[0-9]{1}[0-9 /\\-]{1,31}$");
        private static Regex PATTERN_TOPIC_NAME = new Regex("^[a-zA-Z0-9]{1}[-_a-zA-Z0-9]{0,255}$");
        private static Regex PATTERN_SUBJECT = new Regex("^[^\\r\\n\\t\\f]+$");
        private static Regex PATTERN_TEMPLATE_NAME = new Regex("^[a-zA-Z0-9]{1}([-_a-zA-Z0-9]){0,64}");
        private static Regex PATTERN_SMS_TEMPLATE_NAME = new Regex("^[\u4e00-\u9fa5-a-zA-Z0-9]{0,64}$");
        private const int MAX_DISPLAY_NAME_LENGTH = 192;
        private const int MAX_SUBJECT_LENGTH = 512;
        private const int MAX_MESSAGE_LENGTH = 256 * 1024;
        private const int MAX_TEMPLATE_CONTENT  = 256 * 1024;
        private const int SIGN_MAX_LENGTH = 10;
        private const char SIGNLABEL_CH_LEFT = '【';
        private const char SIGNLABEL_CH_RIGHT = '】';

        /// <summary>
        /// validate phone
        /// </summary>
        /// <param name="phone">phone number</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidatePhone(string phone)
        {
            Match mt = PATTERN_TELTPHONE.Match(phone);
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
            if (string.IsNullOrEmpty(topicName))
            {
                return false;
            }

            Match mt = PATTERN_TOPIC_NAME.Match(topicName);
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

        /// <summary>
        /// validate subject
        /// </summary>
        /// <param name="subject">subject</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateSubject(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                return true;
            }

            byte[] byteArray = System.Text.Encoding.GetEncoding(Constants.UTF8).GetBytes(subject);
            if (byteArray.Length > MAX_SUBJECT_LENGTH)
            {
                return false;
            }

            Match mt = PATTERN_SUBJECT.Match(subject);
            return mt.Success;
        }

        /// <summary>
        /// validate message
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return false;
            }
            byte[] byteArray = System.Text.Encoding.GetEncoding(Constants.UTF8).GetBytes(message);
            return byteArray.Length < MAX_MESSAGE_LENGTH;
        }

        /// <summary>
        /// validate messageStructure lengths
        /// </summary>
        /// <param name="messageStructure">messageStructure</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateMessageStructureLength(string messageStructure)
        {
            if (string.IsNullOrEmpty(messageStructure))
            {
                return false;
            }
            byte[] byteArray = System.Text.Encoding.GetEncoding(Constants.UTF8).GetBytes(messageStructure);
            return byteArray.Length < MAX_MESSAGE_LENGTH;
        }

        /// <summary>
        /// validate messageStructure contain default message
        /// </summary>
        /// <param name="messageStructure">messageStructure</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateMessageStructureDefault(string messageStructure)
        {
            if (string.IsNullOrEmpty(messageStructure))
            {
                return false;
            }
            try
            {
                Dictionary<string, object> dictionary = JsonUtil.UnSerialize<Dictionary<string, object>>(messageStructure);
                return dictionary.ContainsKey(Constants.DEFAULT);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// validate message template content
        /// </summary>
        /// <param name="content">message template content</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateMessageTemplateContent(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return false;
            }
            byte[] byteArray = System.Text.Encoding.GetEncoding(Constants.UTF8).GetBytes(content);
            return byteArray.Length < MAX_TEMPLATE_CONTENT;
        }

        /// <summary>
        /// validate message template name
        /// </summary>
        /// <param name="tempateName">template name</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateMessageTemplateName(string tempateName)
        {
            if (string.IsNullOrEmpty(tempateName))
            {
                return false;
            }
            Match mt = PATTERN_TEMPLATE_NAME.Match(tempateName);
            return mt.Success;
        }

        /// <summary>
        /// validate sms template name
        /// </summary>
        /// <param name="tempateName">sms template name</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateSmsTemplateName(string tempateName)
        {
            if (string.IsNullOrEmpty(tempateName))
            {
                return false;
            }
            return PATTERN_SMS_TEMPLATE_NAME.IsMatch(tempateName);
        }

        /// <summary>
        /// validate message contain sign name
        /// </summary>
        /// <param name="message">message Content</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ContainSignNameFromMessage(String message)
        {
            if (string.IsNullOrEmpty(message) || message.Length < 4)
            {
                return false;
            }

            int scanLegth = message.Length > SIGN_MAX_LENGTH ? SIGN_MAX_LENGTH : message.Length;

            // scan head
            char[] chars = message.ToCharArray();
            if (chars[0] == SIGNLABEL_CH_LEFT)
            {
                for (int i = 1; i < scanLegth; i++)
                {
                    if (chars[i] == SIGNLABEL_CH_RIGHT)
                    {
                        return true;
                    }
                }
            }

            // scan tail
            if (chars[message.Length - 1] == SIGNLABEL_CH_RIGHT)
            {
                for (int i = message.Length - 2; i > message.Length - scanLegth - 1; i--)
                {
                    if (chars[i] == SIGNLABEL_CH_LEFT)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
