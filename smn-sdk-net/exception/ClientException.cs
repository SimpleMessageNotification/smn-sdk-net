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
using System.Runtime.Serialization;

namespace Smn.Exceptions
{
    ///<summary> 
    /// smn client exception
    /// author:zhangyx
    /// version:1.0.0
    ///</summary> 
    [Serializable]
    internal class ClientException : Exception
    {
        public String ErrorCode { get; set; }

        public String ErrorMessage { get; set; }

        public ClientException()
        {
        }

        public ClientException(String errCode, String errMsg)
           : base(errCode + " : " + errMsg)
        {
            ErrorCode = errCode;
            ErrorMessage = errMsg;
        }

        public ClientException(string message) : base(message)
        {
            
        }

        public ClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}