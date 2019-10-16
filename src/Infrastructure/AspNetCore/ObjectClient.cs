﻿using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class ObjectClient : IObjectClient
    {
        public ObjectClient(IClient client, IFormatSerializer serializer, string acceptType, string contentType, Encoding encoding)
        {
            Client = client;
            Serializer = serializer;
            AcceptType = acceptType;
            ContentType = contentType;
            DefaultEncoding = encoding;
        }

        public ObjectClient(IClient client, IFormatSerializer serializer, string acceptType, string contentType)
            : this(client, serializer, acceptType, contentType, Encoding.UTF8) { }

        public IClient Client { get; private set; }

        public IFormatSerializer Serializer { get; private set; }

        public string AcceptType { get; private set; }

        public string ContentType { get; private set; }

        public Encoding DefaultEncoding { get; private set; }

        public async Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri)
        {
            var response = await Client.GetAsync(uri, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task<IClientResponse> GetAsync(string uri)
        {
            return Client.GetAsync(uri);
        }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>()
        {
            throw new NotImplementedException();
        }

        public Task<IClientResponse> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var content = Serialize(request);
            var response = await Client.PostAsync(uri, content, ContentType, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task<IClientResponse> PostAsync<TRequest>(string uri, TRequest request)
        {
            var content = Serialize(request);
            return Client.PostAsync(uri, content, ContentType);
        }

        public Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IClientResponse> PostAsync<TRequest>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var content = Serialize(request);
            var response = await Client.PutAsync(uri, content, ContentType, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task<IClientResponse> PutAsync<TRequest>(string uri, TRequest request)
        {
            var content = Serialize(request);
            return Client.PutAsync(uri, content, ContentType);
        }

        public async Task<IObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri)
        {
            var response = await Client.DeleteAsync(uri, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task<IClientResponse> DeleteAsync(string uri)
        {
            return Client.DeleteAsync(uri);
        }

        #region Helper

        private string Serialize<T>(T data)
        {
            return Serializer.Serialize(data);
        }

        private IObjectClientResponse<T> Deserialize<T>(IClientResponse response)
        {
            var contentString = response.ContentString;
            var content = Serializer.Deserialize<T>(contentString);
            var problemDetails = DeserializeProblemDetails(contentString);

            return new ObjectClientResponse<T>(response, content, problemDetails);
        }

        private IProblemDetails DeserializeProblemDetails(string contentString)
        {
            try
            {
                return Serializer.Deserialize<ProblemDetailsResponse>(contentString);
            }
            catch (Exception)
            {
                // TODO: https://github.com/optivem/framework-dotnetcore/issues/273
                return null;
            }
        }

        #endregion Helper
    }
}