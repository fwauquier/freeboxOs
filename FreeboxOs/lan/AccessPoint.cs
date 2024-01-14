// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public sealed class AccessPoint : JsonModel {
	public string? mac{ get; init; }               // ": "34:27:92:62:0D:6A",
	public string? type{ get; init; }              // ": "gateway",
	public string? connectivity_type{ get; init; } // ": "ethernet",
	public string? uid{ get; init; }               // ": "603c20edd63beae54153f11170be4c48",
	public long tx_bytes{ get; init; }             // ": 184175461814,
	public long rx_bytes{ get; init; }             // ": 11609747369,
	public long tx_rate{ get; init; }              // ": 184175461814,
	public long rx_rate{ get; init; }              // ": 11609747369,
	public EthernetInformation? ethernet_information{ get; init; }
	public WifiInformation? wifi_information{ get; init; }
}
