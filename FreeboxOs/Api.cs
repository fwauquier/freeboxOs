// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;

// https://dev.freebox.fr/sdk/os/
// Most API uses the REST architecture, pay attention to the http methods used for each request.
// The API response is always a JSON object using utf8 encoding.
public sealed partial class Api : IDisposable {
	public static readonly JsonSerializerOptions jsonOption = new() {
		AllowTrailingCommas = false,
		DefaultBufferSize = 0,
		WriteIndented = false,
		IgnoreReadOnlyFields = true,
		IgnoreReadOnlyProperties = true,
		IncludeFields = false,
		MaxDepth = 0,
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
		UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
		Converters = {
			//new UnixEpochDateTimeConverter(),
			new JsonStringEnumConverter()
		}
	};

	private readonly HttpClient _httpClient;
	private readonly string _password;

	public Api(Uri uri, string password) {
		_password = password;
		_httpClient = new HttpClient { BaseAddress = uri };
		_httpClient.DefaultRequestHeaders.Add("X-FBX-FREEBOX0S", "1");
	}

	public string app_id { get; init; } = "FWA_FreeboxOs";
	public string app_name { get; init; } = "FWA_FreeboxOs";
	public string app_version { get; init; } = "1.0.0";
	public string device_name { get; init; } = Environment.MachineName;


	public ILogger? Logger { get; set; } = null;

	public void Dispose() {
		EnsureLogOffAsync().GetAwaiter().GetResult();
		_httpClient.Dispose();
	}

	private T? Deserialize<T>(string jsonString) where T : class {
		Logger?.LogTrace("Deserialize: {JsonString}", jsonString);
		var deserialize = JsonSerializer.Deserialize<Response<T>>(jsonString);
		if (deserialize is null) throw new ApiException($"Cannot deserialize response to {typeof(T).FullName}");
		if (deserialize.Success == false) throw new ApiException($"Response is not successfully. Code:{deserialize.ErrorCode} Message:{deserialize.ErrorMessage}");

		return deserialize.Result !;
	}

	public async Task<T?> GetAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, bool addVersion = true) where T : class {
		return Deserialize<T>(await GetAsync(requestUri, addVersion).ConfigureAwait(false));
	}

	public async Task<string> GetAsync([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, bool addVersion = true) {
		if (addVersion) requestUri = await ReformatUri(requestUri).ConfigureAwait(false);
		Logger?.LogDebug("[GET] {RequestUri}", requestUri);
		var response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);

		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}

	public async Task<string> PostAsync([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, HttpContent? content = null, bool addVersion = true) {
		if (addVersion) requestUri = await ReformatUri(requestUri).ConfigureAwait(false);
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
		if (addVersion) requestUri = await ReformatUri(requestUri).ConfigureAwait(false);
		Logger?.LogDebug("[POST] {RequestUri}", requestUri);

		var response = await _httpClient.PostAsync(requestUri, CreateContent(content)).ConfigureAwait(false);

		// Check if the request was successful
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}

	public async Task<T?> PostAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, object? content = null, bool addVersion = true) where T : class {
		return Deserialize<T>(await PostAsync(requestUri, content, addVersion).ConfigureAwait(false));
	}

	public HttpContent? CreateContent(object? content) {
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

	private sealed class Response<T> where T : class {
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
