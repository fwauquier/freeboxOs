// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs;

public sealed partial class Api{
/*
 	private const string ReceiversPath = "/api/v3/airmedia/receivers/";
	public async Task<IEnumerable<AirmediaResult>> ListAirmediaReceivers() {
		var jsonString = await _httpClient.GetStringAsync(ReceiversPath);
		var response = JsonSerializer.Deserialize<Response<List<AirmediaResult>>>(jsonString);
		return response.Result;
	}


 public async Task<bool> SendAirMediaReceiverRequest(string receiverName, AirMediaReceiverRequest request) {
		var payload = JsonConvert.SerializeObject
		(
			request,
			new JsonSerializerSettings { Converters = new JsonConverter[] { new StringEnumConverter { CamelCaseText = true } } }
		);

		var stringContent = new StringContent(payload, Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync(ReceiversPath + receiverName, stringContent);
		dynamic result = JObject.Parse(await response.Content.ReadAsStringAsync());
		return result.success;
	}
	*/

}
