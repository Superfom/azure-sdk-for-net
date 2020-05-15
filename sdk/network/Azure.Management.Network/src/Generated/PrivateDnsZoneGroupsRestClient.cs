// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Management.Network.Models;

namespace Azure.Management.Network
{
    internal partial class PrivateDnsZoneGroupsRestClient
    {
        private string subscriptionId;
        private Uri endpoint;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of PrivateDnsZoneGroupsRestClient. </summary>
        public PrivateDnsZoneGroupsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            endpoint ??= new Uri("https://management.azure.com");

            this.subscriptionId = subscriptionId;
            this.endpoint = endpoint;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateDeleteRequest(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/privateEndpoints/", false);
            uri.AppendPath(privateEndpointName, true);
            uri.AppendPath("/privateDnsZoneGroups/", false);
            uri.AppendPath(privateDnsZoneGroupName, true);
            uri.AppendQuery("api-version", "2020-04-01", true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Deletes the specified private dns zone group. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="privateDnsZoneGroupName"> The name of the private dns zone group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteAsync(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (privateDnsZoneGroupName == null)
            {
                throw new ArgumentNullException(nameof(privateDnsZoneGroupName));
            }

            using var message = CreateDeleteRequest(resourceGroupName, privateEndpointName, privateDnsZoneGroupName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 200:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Deletes the specified private dns zone group. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="privateDnsZoneGroupName"> The name of the private dns zone group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (privateDnsZoneGroupName == null)
            {
                throw new ArgumentNullException(nameof(privateDnsZoneGroupName));
            }

            using var message = CreateDeleteRequest(resourceGroupName, privateEndpointName, privateDnsZoneGroupName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 200:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/privateEndpoints/", false);
            uri.AppendPath(privateEndpointName, true);
            uri.AppendPath("/privateDnsZoneGroups/", false);
            uri.AppendPath(privateDnsZoneGroupName, true);
            uri.AppendQuery("api-version", "2020-04-01", true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Gets the private dns zone group resource by specified private dns zone group name. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="privateDnsZoneGroupName"> The name of the private dns zone group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PrivateDnsZoneGroup>> GetAsync(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (privateDnsZoneGroupName == null)
            {
                throw new ArgumentNullException(nameof(privateDnsZoneGroupName));
            }

            using var message = CreateGetRequest(resourceGroupName, privateEndpointName, privateDnsZoneGroupName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PrivateDnsZoneGroup value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = PrivateDnsZoneGroup.DeserializePrivateDnsZoneGroup(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets the private dns zone group resource by specified private dns zone group name. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="privateDnsZoneGroupName"> The name of the private dns zone group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PrivateDnsZoneGroup> Get(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (privateDnsZoneGroupName == null)
            {
                throw new ArgumentNullException(nameof(privateDnsZoneGroupName));
            }

            using var message = CreateGetRequest(resourceGroupName, privateEndpointName, privateDnsZoneGroupName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PrivateDnsZoneGroup value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = PrivateDnsZoneGroup.DeserializePrivateDnsZoneGroup(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName, PrivateDnsZoneGroup parameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/privateEndpoints/", false);
            uri.AppendPath(privateEndpointName, true);
            uri.AppendPath("/privateDnsZoneGroups/", false);
            uri.AppendPath(privateDnsZoneGroupName, true);
            uri.AppendQuery("api-version", "2020-04-01", true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(parameters);
            request.Content = content;
            return message;
        }

        /// <summary> Creates or updates a private dns zone group in the specified private endpoint. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="privateDnsZoneGroupName"> The name of the private dns zone group. </param>
        /// <param name="parameters"> Parameters supplied to the create or update private dns zone group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> CreateOrUpdateAsync(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName, PrivateDnsZoneGroup parameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (privateDnsZoneGroupName == null)
            {
                throw new ArgumentNullException(nameof(privateDnsZoneGroupName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var message = CreateCreateOrUpdateRequest(resourceGroupName, privateEndpointName, privateDnsZoneGroupName, parameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                case 200:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Creates or updates a private dns zone group in the specified private endpoint. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="privateDnsZoneGroupName"> The name of the private dns zone group. </param>
        /// <param name="parameters"> Parameters supplied to the create or update private dns zone group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CreateOrUpdate(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName, PrivateDnsZoneGroup parameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (privateDnsZoneGroupName == null)
            {
                throw new ArgumentNullException(nameof(privateDnsZoneGroupName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var message = CreateCreateOrUpdateRequest(resourceGroupName, privateEndpointName, privateDnsZoneGroupName, parameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                case 200:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListRequest(string privateEndpointName, string resourceGroupName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/privateEndpoints/", false);
            uri.AppendPath(privateEndpointName, true);
            uri.AppendPath("/privateDnsZoneGroups", false);
            uri.AppendQuery("api-version", "2020-04-01", true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Gets all private dns zone groups in a private endpoint. </summary>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PrivateDnsZoneGroupListResult>> ListAsync(string privateEndpointName, string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            using var message = CreateListRequest(privateEndpointName, resourceGroupName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PrivateDnsZoneGroupListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = PrivateDnsZoneGroupListResult.DeserializePrivateDnsZoneGroupListResult(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets all private dns zone groups in a private endpoint. </summary>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PrivateDnsZoneGroupListResult> List(string privateEndpointName, string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            using var message = CreateListRequest(privateEndpointName, resourceGroupName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PrivateDnsZoneGroupListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = PrivateDnsZoneGroupListResult.DeserializePrivateDnsZoneGroupListResult(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string privateEndpointName, string resourceGroupName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Gets all private dns zone groups in a private endpoint. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PrivateDnsZoneGroupListResult>> ListNextPageAsync(string nextLink, string privateEndpointName, string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            using var message = CreateListNextPageRequest(nextLink, privateEndpointName, resourceGroupName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PrivateDnsZoneGroupListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = PrivateDnsZoneGroupListResult.DeserializePrivateDnsZoneGroupListResult(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets all private dns zone groups in a private endpoint. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PrivateDnsZoneGroupListResult> ListNextPage(string nextLink, string privateEndpointName, string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (privateEndpointName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointName));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            using var message = CreateListNextPageRequest(nextLink, privateEndpointName, resourceGroupName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PrivateDnsZoneGroupListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = PrivateDnsZoneGroupListResult.DeserializePrivateDnsZoneGroupListResult(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
