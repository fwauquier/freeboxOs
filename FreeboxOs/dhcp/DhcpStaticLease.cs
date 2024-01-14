// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lan;

namespace FreeboxOs.dhcp;

public sealed class DhcpStaticLease : JsonModel {

	/// <summary>DHCP static lease object id   </summary>
	public   string? id { get; set; }
	/// <summary> Host mac address  </summary>
	public   string? mac { get; set; }
	/// <summary>  an optional comment </summary>
	public   string? comment { get; set; }
	/// <summary>  hostname matching the mac address </summary>
	public   string? hostname { get; init; }
	/// <summary> IPv4 to assign to the host  </summary>
	public   string? ip { get; set; }
	/// <summary>   </summary>
	public   LanHost? host { get; init; }
	





}
