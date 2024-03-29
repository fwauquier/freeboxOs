// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using System.Diagnostics.CodeAnalysis;
using System.Text;
using FreeboxOs.version;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;
 

// https://dev.freebox.fr/sdk/os/
// Most API uses the REST architecture, pay attention to the http methods used for each request.
// The API response is always a JSON object using utf8 encoding.
public sealed partial class Api : IDisposable {
	private static readonly JsonSerializerOptions jsonOption = new JsonSerializerOptions
	                                                           {
		                                                           AllowTrailingCommas = false,
		                                                           DefaultBufferSize = 0,
		                                                           WriteIndented = false,
		                                                           IgnoreReadOnlyFields = true,
		                                                           IgnoreReadOnlyProperties = true,
		                                                           IncludeFields = false,
		                                                           MaxDepth = 64,
		                                                           DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
		                                                           DictionaryKeyPolicy = null,
		                                                           Encoder = null,
		                                                           UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode,
		                                                           NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
		                                                           PreferredObjectCreationHandling = JsonObjectCreationHandling.Replace,
		                                                           PropertyNameCaseInsensitive = false,
		                                                           PropertyNamingPolicy = null,
		                                                           TypeInfoResolver = null,
		                                                           ReadCommentHandling = JsonCommentHandling.Skip,
		                                                           UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip,
		                                                          
	                                                           };

	private readonly HttpClient _httpClient;
	private readonly string _password;
 

	public Api(Uri uri, string password) {
		_password = password;
		_httpClient = new HttpClient {BaseAddress = uri};
		_httpClient.DefaultRequestHeaders.Add("X-FBX-FREEBOX0S", "1");
	}

	public string app_id { get; set; } = "FWA_FreeboxOs";
	public string app_name { get; set; } = "FWA_FreeboxOs";
	public string app_version { get; set; } = "1.0.0";
	public string device_name { get; set; } = Environment.MachineName;

	private ApiVersion? _apiVersion;

	public  string  ReformatUri(string uri,bool useVersion=false) {
		if (useVersion) {
			//  https://[api_domain]:[freebox_port]/[api_base_url]/v[major_api_version]/[api_url]
			var apiVersion        = _apiVersion ??= GetVersionAsync().ConfigureAwait(false).GetAwaiter().GetResult();
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
		}
		return $"/api/latest/{uri.Trim('/')}";
	}

	public ILogger? Logger { get; set; }

	public void Dispose() {
		EnsureLogOffAsync().GetAwaiter().GetResult();
		_httpClient.Dispose();
	}

	private T? Deserialize<T>(string jsonString) where T : class {
	 
		Logger?.LogTrace("Deserialize: {JsonString}", jsonString);
		Response<T>? deserialize;
#if DEBUG
		jsonString = JsonModel.Reformat(jsonString);
		try {
			deserialize = JsonSerializer.Deserialize<Response<T>>(jsonString);
		} catch (System.Text.Json.JsonException e) {

		 
			var lines        = jsonString.Split(Environment.NewLine);
			var iLine        = e.LineNumber?? int.MaxValue;
			var line         = lines.Length > iLine ? lines[iLine] : string.Empty;

			throw new ApiException($"Cannot deserialize response to {typeof(T).FullName}:{e.Message}"
			                       + $"{Environment.NewLine}Line: {iLine}"
			                       + $"{Environment.NewLine}BytePositionInLine: {e.BytePositionInLine}"
			                       + $"{Environment.NewLine}Path:{e.Path}"
									+ $"{Environment.NewLine}Line content:{line}"
			                       + $"{Environment.NewLine}{jsonString}", e);
		}

#else
         deserialize = JsonSerializer.Deserialize<Response<T>>(jsonString);
#endif

        if (deserialize is null) throw new ApiException($"Cannot deserialize response to {typeof(T).FullName}");
		if (deserialize.Success == false) throw new ApiException($"Response is not successfully. Code:{deserialize.ErrorCode} Message:{deserialize.ErrorMessage}");
		var result = deserialize.Result;
#if DEBUG
		if (result is JsonModel jsonModel)
		{
			jsonModel.EnsureAllDataDeserialized();
		}
		else if (result is IEnumerable<JsonModel> jsonModels)
		{
			foreach (var jsonModel2 in jsonModels)
			{
				jsonModel2.EnsureAllDataDeserialized();
			}
		}
#endif
        return result;
	}

	public async Task<T?> GetAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, bool addVersion = true) where T : class {
		return Deserialize<T>(await GetAsync(requestUri, addVersion).ConfigureAwait(false));
	}

	public async Task<string> GetAsync([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, bool addVersion = true) {
		if (addVersion) requestUri =  ReformatUri(requestUri);
		Logger?.LogDebug("[GET] {RequestUri}", requestUri);
		var response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);

		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}

	public async Task<string> PostAsync([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, HttpContent? content = null, bool addVersion = true) {
		if (addVersion) requestUri = ReformatUri(requestUri);
		Logger?.LogDebug("[POST] {RequestUri}", requestUri);
		var response = await _httpClient.PostAsync(requestUri, content).ConfigureAwait(false);

		// Check if the request was successful
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}

	public async Task<T?> PostAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, HttpContent? content = null, bool addVersion = true) where T : class {
		return Deserialize<T>(await PostAsync(requestUri, content, addVersion).ConfigureAwait(false));
	}

	public async Task<string> PostAsync([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, object? content = null, bool addVersion = true) {
		if (addVersion) requestUri = ReformatUri(requestUri);
		Logger?.LogDebug("[POST] {RequestUri}", requestUri);

		using var httpContent = CreateContent(content);
		var response    = await _httpClient.PostAsync(requestUri, httpContent).ConfigureAwait(false);

		// Check if the request was successful
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}

	public async Task<T?> PostAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, object? content = null, bool addVersion = true) where T : class {
		return Deserialize<T>(await PostAsync(requestUri, content, addVersion).ConfigureAwait(false));
	}

	public static HttpContent? CreateContent(object? content) {
		if (content is null) return null;
		return new StringContent(JsonSerializer.Serialize(content, jsonOption), Encoding.UTF8, "application/json");
	}

// private async Task<T> PostAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string? requestUri, HttpContent? content) where T : class {
// 		Logger?.LogDebug("[POST] {RequestUri}", requestUri);
// 		var response = await _httpClient.PostAsync(requestUri, content).ConfigureAwait(false);
//
// 		// Check if the request was successful
// 		if (response.IsSuccessStatusCode) {
// 			var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
// 			return Deserialize<T>(jsonString);
// 		}
// 		throw new ApiException($"Request failed with status code {response.StatusCode}");
// 	}

#pragma warning disable CA1812 // Avoid uninstantiated internal classes
	private sealed class Response<T> where T : class {
#pragma warning restore CA1812 // Avoid uninstantiated internal classes
		/// <summary>
		///     In cas of error, provides a French error message relative to the error
		/// </summary>
		[JsonPropertyName("msg")]
		public bool? ErrorMessage { get; init; }

		/// <summary>
		///     indicates if the request was successful
		/// </summary>
		[JsonPropertyName("success")]
		public bool Success { get; init; }

		/// <summary>
		///     In case of request error, this error_code provides information about the error. The possible error_code values are documented for each API.
		/// </summary>
		[JsonPropertyName("error_code ")]
		public bool ErrorCode { get; init; }

		/// <summary>
		///     the result of the request. (It may be omitted if the request does not expect any result)
		/// </summary>
		[JsonPropertyName("result")]
		public T? Result { get; init; }
	}
}
