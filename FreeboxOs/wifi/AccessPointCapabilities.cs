// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class AccessPointCapabilities : JsonModel {
	[JsonPropertyName("6g")]
	public AccessPointCapability? _6G { get; set; }
	[JsonPropertyName("5g")]
	public AccessPointCapability? _gG { get; set; }
	[JsonPropertyName("2d4g")]
	public AccessPointCapability? _2d4g { get; set; }
	[JsonPropertyName("60g")]
	public AccessPointCapability? _60g { get; set; }
}
