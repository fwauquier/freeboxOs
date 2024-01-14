// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.dhcp;

/// <summary>
/// When attempting to access the DHCP API, you may encounter the following errors:
/// </summary>
public enum DhcpError {
	/// <summary>  invalid argument</summary>
	inval  ,
	/// <summary>   invalid netmask</summary>
	inval_netmask ,
	/// <summary>  invalid IP range</summary>
	inval_ip_range ,
	/// <summary>  IP range and netmask mismatch</summary>
	inval_ip_range_net ,
	/// <summary>   gateway and netmask mismatch</summary>
	inval_gw_net  ,
	/// <summary> already exists</summary>
	exist   ,
	/// <summary> no such device</summary>
	nodev   ,
	/// <summary>  no such entry</summary>
	noent  ,
	/// <summary> network is down</summary>
	netdown ,
	/// <summary> device or resource busy</summary>
	busy  , 
}
