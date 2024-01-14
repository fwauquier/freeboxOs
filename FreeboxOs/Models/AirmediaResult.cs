// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public class AirmediaResult {
	[JsonPropertyName("capabilities")] public   Capabilities? Capabilities { get; set; }

	[JsonPropertyName("name")] public   string? Name { get; set; }

	[JsonPropertyName("password_protected")]
	public bool? PasswordProtected { get; set; }
}
