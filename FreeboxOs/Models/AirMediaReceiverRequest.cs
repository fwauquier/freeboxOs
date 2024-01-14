// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public class AirMediaReceiverRequest {
	[JsonPropertyName("action")] public Action Action { get; set; }

	[JsonPropertyName("media_type")] public MediaType MediaType { get; set; }

	[JsonPropertyName("password")] public required string Password { get; set; }

	[JsonPropertyName("position")] public int Position { get; set; }

	[JsonPropertyName("media")] public required string Media { get; set; }
}
