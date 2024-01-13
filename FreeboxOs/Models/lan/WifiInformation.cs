// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public sealed class WifiInformation : JsonModel {
	public string band { get; init; }
	public string ssid{ get; init; }
	public long signal{ get; init; }
	public long phy_rx_rate{ get; init; }
	public long phy_tx_rate{ get; init; }
	public string standard{ get; init; }
}
