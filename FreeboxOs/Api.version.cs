// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.version;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;

public sealed partial class Api {


	public async Task<ApiVersion> GetVersionAsync() {
		var jsonString = await GetAsync("/api_version", false).ConfigureAwait(false);
		Logger?.LogTrace("Deserialize: {JsonString}", jsonString);
		return JsonSerializer.Deserialize<ApiVersion>(jsonString) ?? throw new ApiException($"Cannot deserialize response to {typeof(object).FullName}");
	}
}
