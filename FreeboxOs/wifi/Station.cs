// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lan;

namespace FreeboxOs.wifi;

public sealed class Station : JsonModel {
	public required long rx_bytes { get; init; }
	public required long tx_bytes { get; init; }
	public required string bssid { get; init; }
	public required Host host { get; init; }

	public required string hostname { get; init; }
	public required string mac { get; init; }
	// Todo convert to enum
	public required string access_type { get; init; }
	public required int custom_key_id { get; init; }
	public required string id { get; init; }
	// Todo convert to enum
	public required string pairwise_cipher { get; init; }
	// Todo convert to enum
	public required string wpa_alg { get; init; }
	// Todo convert to enum
	public required string state { get; init; }
	public required int inactive { get; init; }
	public required int tx_rate { get; init; }
	[JsonConverter(typeof(TimeSpanConverter))]
	public required TimeSpan conn_duration { get; init; }
	public required int rx_rate { get; init; }
	public required int signal { get; init; }

	public StationTx? last_tx { get; init; }
	public StationTx? last_rx { get; init; }
	public StationFlag? flags { get; init; }
}
