// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public class Capabilities {
	[JsonPropertyName("photo")] public bool Photo { get; set; }

	[JsonPropertyName("screen")] public bool Screen { get; set; }

	[JsonPropertyName("audio")] public bool Audio { get; set; }

	[JsonPropertyName("video")] public bool Video { get; set; }
}
