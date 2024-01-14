// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.dhcp;

public sealed class DhcpConfig : JsonModel {

	/// <summary> Enable/Disable the DHCP server  </summary>
	public required bool enabled { get; set; }
	/// <summary> Always assign the same IP to a given host  </summary>
	public required bool sticky_assign { get; set; }
	/// <summary>  Gateway IP address </summary>
	public required string gateway { get; init; }
	/// <summary>  Gateway subnet netmask </summary>
	public required string netmask { get; init; }
	/// <summary>  DHCP range start IP </summary>
	public required string ip_range_start { get; set; }
	/// <summary>  DHCP range end IP </summary>
	public required string ip_range_end { get; set; }
	/// <summary> Always broadcast DHCP responses  </summary>
	public required bool always_broadcast { get; set; }
	/// <summary> List of dns servers to include in DHCP reply  </summary>
	public required string[] dns { get; set; }
 




}
