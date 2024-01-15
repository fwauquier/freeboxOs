// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class StationTx : JsonModel {
	public required long bitrate { get; init; }
	public required long mcs { get; init; }
	public required bool shortgi { get; init; }
	public required long he_mcs { get; init; }
	public required long vht_mcs { get; init; }
	public required long vht_nss { get; init; }
	public required long he_nss { get; init; }
	public required string width { get; init; }
}
