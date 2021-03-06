﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline.Policies
{
    public class ClientRequestIdPolicy : SynchronousHttpPipelinePolicy
    {
        private const string ClientRequestIdHeader = "x-ms-client-request-id";
        private const string EchoClientRequestId = "x-ms-return-client-request-id";

        protected ClientRequestIdPolicy()
        {
        }

        public static ClientRequestIdPolicy Singleton { get; } = new ClientRequestIdPolicy();

        public override void OnSendingRequest(HttpPipelineMessage message)
        {
            message.Request.Headers.Add(ClientRequestIdHeader, message.Request.ClientRequestId);
            message.Request.Headers.Add(EchoClientRequestId, "true");
        }
    }
}
