// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.Caching.Distributed;

public interface IDistributedCache<T>
{
    [SuppressMessage("ApiDesign", "RS0026:Do not add multiple public overloads with optional parameters", Justification = "Does not cause ambiguity due to callback signature delta")]
    ValueTask<T> GetAsync(string key, Func<CancellationToken, ValueTask<T>> callback, DistributedCacheEntryOptions? options = null, CancellationToken cancellationToken = default);

    [SuppressMessage("ApiDesign", "RS0026:Do not add multiple public overloads with optional parameters", Justification = "Does not cause ambiguity due to callback signature delta")]
    ValueTask<T> GetAsync<TState>(string key, TState state, Func<TState, CancellationToken, ValueTask<T>> callback, DistributedCacheEntryOptions? options = null, CancellationToken cancellationToken = default);

    ValueTask RemoveAsync(string key, CancellationToken cancellationToken = default);
}

