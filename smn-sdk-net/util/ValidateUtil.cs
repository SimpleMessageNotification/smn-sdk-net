using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return offset >= 0 ? true : false;
        }

        /// <summary>
        /// validate limit
        /// </summary>
        /// <param name="limit">limit</param>
        /// <returns>if match return true, else return false</returns>
        public static bool ValidateLimit(int limit)
        {
            return (limit > 0 && limit <= 100) ? true : false;
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
    }
}
