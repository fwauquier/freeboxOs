// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using Microsoft.Extensions.Logging;

namespace FreeboxOs;

public sealed partial class Api {
	private ApiVersion? _apiVersion;

	public async Task<string> ReformatUri(string uri) {
		var apiVersion = _apiVersion ??= await GetVersionAsync().ConfigureAwait(false);

		//https://[api_domain]:[freebox_port]/[api_base_url]/v[major_api_version]/[api_url]

		var api_domain        = apiVersion.api_domain;
		var freebox_port      = apiVersion.https_port;
		var api_base_url      = apiVersion.api_base_url;
		var major_api_version = apiVersion.api_version.Split('.')[0];
		if (string.IsNullOrWhiteSpace(api_domain)) return uri;
		if (freebox_port < 433) return uri;
		if (string.IsNullOrWhiteSpace(api_base_url)) return uri;
		if (string.IsNullOrWhiteSpace(apiVersion.api_version)) return uri;
		if (string.IsNullOrWhiteSpace(api_domain)) return uri;
		return $"{api_base_url}v{major_api_version}/{uri.Trim('/')}";

		//return $"https://{api_domain}:{freebox_port}/{api_base_url}/v{major_api_version}/{uri.Trim('/')}";
	}

	public async Task<ApiVersion> GetVersionAsync() {
		var jsonString = await GetAsync("/api_version", false).ConfigureAwait(false);
		Logger?.LogTrace("Deserialize: {JsonString}", jsonString);
		return JsonSerializer.Deserialize<ApiVersion>(jsonString) ?? throw new ApiException($"Cannot deserialize response to {typeof(object).FullName}");
	}
}
