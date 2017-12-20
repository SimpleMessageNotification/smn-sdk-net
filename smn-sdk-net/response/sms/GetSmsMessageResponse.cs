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

namespace Smn.Response.Sms
{
    ///<summary> 
    /// get sms message response message
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    public class GetSmsMessageResponse : BaseResponse
    {
        /// <summary>
        /// message
        /// </summary>
        private string message;

        /// <summary>
        /// 这里不设属性标记，跟BaseResponse中的errorMessage冲突，
        /// 重写GetResponse方法解决
        /// </summary>
        public string Message { get => message; set => message = value; }
    }
}
