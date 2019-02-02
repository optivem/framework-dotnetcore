﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Platform.Core.Common.RestClient
{
    public interface IRestControllerClient<TId,
        TGetCollectionResponse, TGetResponse,
        TPostRequest, TPostResponse,
        TPutRequest, TPutResponse,
        TPatchRequest, TPatchResponse>
        : IDisposable
    {
        Task<TGetCollectionResponse> GetAsync();

        Task<TGetResponse> GetAsync(TId id);
        
        Task<TPostResponse> PostAsync(TPostRequest request);

        Task<TPutResponse> PutAsync(TId id, TPutRequest request);

        Task<TPatchResponse> PatchAsync(TId id, TPatchRequest request);

        Task DeleteAsync(TId id);
    }

    public interface IRestControllerClient<TId, TRequest, TResponse>
        : IRestControllerClient<TId, 
            List<TResponse>, TResponse,
            TRequest, TResponse,
            TRequest, TResponse,
            TRequest, TResponse>
    {

    }

    public interface IRestControllerClient<TId, TDto>
        : IRestControllerClient<TId, TDto, TDto>
    {

    }
}
