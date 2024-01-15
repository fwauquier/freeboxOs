// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class StationFlag : JsonModel {
	[JsonPropertyName("6g")]
	public required bool _6g { get; init; }
	[JsonPropertyName("5g")]
	public required bool _5g { get; init; }
	[JsonPropertyName("authorized")]
	public required bool authorized { get; init; }
	[JsonPropertyName("ht")]
	public required bool ht { get; init; }
	[JsonPropertyName("2d4g")]
	public required bool _2d4g { get; init; }
	[JsonPropertyName("legacy")]
	public required bool legacy { get; init; }
	[JsonPropertyName("he")]
	public required bool he { get; init; }
	[JsonPropertyName("vht")]
	public required bool vht { get; init; }
}
