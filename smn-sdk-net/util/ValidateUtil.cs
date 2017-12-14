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
    }
}
