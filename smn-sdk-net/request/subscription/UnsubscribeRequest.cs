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
using System.Text;
using Newtonsoft.Json;
using Smn.Http;
using Smn.Response.Subscription;
using Smn.Util;

namespace Smn.Request.Subscription
{
    public class UnsubscribeRequest : AbstractRequest<UnsubscribeResponse>
    {

        /// <summary>
        /// subscription_urn
        /// </summary>
        private string subscriptionUrn;

        [JsonIgnore]
        public string SubscriptionUrn { get => subscriptionUrn; set => subscriptionUrn = value; }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.DELETE;
        }

        public override string GetUrl()
        {
            if (string.IsNullOrEmpty(subscriptionUrn))
            {
                throw new ArgumentException("subscription urn is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmnServiceUrl());
            sb.Append(Constants.URL_DELIMITER).Append(Constants.V2).Append(Constants.URL_DELIMITER)
                    .Append(ProjectId).Append(Constants.URL_DELIMITER).Append(Constants.SMN_NOTIFICATIONS)
                    .Append(Constants.URL_DELIMITER).Append(Constants.SUBSCRIPTIONS)
                    .Append(Constants.URL_DELIMITER).Append(subscriptionUrn);

            return sb.ToString();
        }
    }
}
