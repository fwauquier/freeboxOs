// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using FreeboxOs.Models;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;

sealed partial class Api{

	ApiVersion? _apiVersion;




	public async Task<string> ReformatUri(string uri) {
		var apiVersion = _apiVersion ??= await GetVersionAsync().ConfigureAwait(false);
		//https://[api_domain]:[freebox_port]/[api_base_url]/v[major_api_version]/[api_url]

		var api_domain = apiVersion.api_domain;
		var freebox_port = apiVersion.https_port;
		var api_base_url = apiVersion.api_base_url;
		var major_api_version = apiVersion.api_version.Split('.')[0];
		if (string.IsNullOrWhiteSpace(api_domain)) return uri;
		if (freebox_port<433) return uri;
		if (string.IsNullOrWhiteSpace(api_base_url)) return uri;
		if (string.IsNullOrWhiteSpace(apiVersion.api_version)) return uri;
		if (string.IsNullOrWhiteSpace(api_domain)) return uri;
		return $"{api_base_url}v{major_api_version}/{uri.Trim('/')}";
		//return $"https://{api_domain}:{freebox_port}/{api_base_url}/v{major_api_version}/{uri.Trim('/')}";
	}
	public async Task<ApiVersion> GetVersionAsync() {

		var jsonString = await GetAsync("/api_version",addVersion:false).ConfigureAwait(false);
		Logger?.LogTrace("Deserialize: {JsonString}", jsonString);
		var deserialize = JsonSerializer.Deserialize<ApiVersion>(jsonString);
		if (deserialize is null) throw new ApiException($"Cannot deserialize response to {typeof(object).FullName}");
		return deserialize;
		/*
		 {
  "api_version": "10.2",
  "device_type": "FreeboxServer7,1",
  "api_base_url": "/api/",
  "uid": "603c20edd63beae54153f11170be4c48",
  "api_domain": "sw6jdjyq.fbxos.fr",
  "https_available": true,
  "https_port": 41254,
  "box_model_name": "Freebox v7 (r1)",
  "device_name": "Freebox Server",
  "box_model": "fbxgw7-r1/full"
}
		 */
	}


}
