// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs;

public sealed partial class Api{
	/*
	private const string DownloadsPath = "/api/v3/downloads/";

		public async Task<IEnumerable<Download>> ListDownloads() {
		var jsonString = await _httpClient.GetStringAsync(DownloadsPath);
		var response = JsonSerializer.Deserialize<Response<List<Download>>>(jsonString);
		return response.Result;
	}

	public async Task<AddDownloadResult> AddDownload(Uri downloadUri) {
		return await AddDownload(new AddDownload { DownloadUrl = downloadUri });
	}

	public async Task<AddDownloadResult> AddDownload(Uri downloadUri, string username, string password) {
		return await AddDownload(new AddDownload { DownloadUrl = downloadUri, Username = username, Password = password });
	}

	private async Task<AddDownloadResult> AddDownload(AddDownload parameter) {
		var payload = new Dictionary<string, string>();
		var singleDownload = false;
		if (parameter.DownloadUrls != null && parameter.DownloadUrls.Any()) {
			// TODO
		} else if (parameter.DownloadUrl != null) {
			singleDownload = true;
			payload["download_url"] = parameter.DownloadUrl.ToString();
		} else {
			throw new ArgumentException("No download url");
		}

		if (parameter.Username != null)
			payload["username"] = parameter.Username;

		if (parameter.Password != null)
			payload["password"] = parameter.Password;

		var response = await _httpClient.PostAsync(DownloadsPath + "add", new FormUrlEncodedContent(payload));
		var jsonResult = JObject.Parse(await response.Content.ReadAsStringAsync());
		var addDownloadResult = new AddDownloadResult { Success = jsonResult["success"].ToObject<bool>(), TaskId = new List<int>() };

		if (singleDownload)
			addDownloadResult.TaskId.Add(jsonResult["result"]["id"].ToObject<int>());
		else
			addDownloadResult.TaskId.AddRange(jsonResult["result"]["id"].ToObject<List<int>>());

		return addDownloadResult;
	}
 */
}
