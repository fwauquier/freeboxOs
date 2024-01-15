// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class ApCapabilities : JsonModel {
	[JsonPropertyName("6g")]
	public ApCapability? _6G { get; set; }
	[JsonPropertyName("5g")]
	public ApCapability? _gG { get; set; }
	[JsonPropertyName("2d4g")]
	public ApCapability? _2d4g { get; set; }
	[JsonPropertyName("60g")]
	public ApCapability? _60g { get; set; }
}
