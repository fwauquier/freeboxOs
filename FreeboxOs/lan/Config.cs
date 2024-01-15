// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.lan;

public sealed class Config : JsonModel {
	/// <summary> Freebox Server IPv4 address </summary>
	public   string? ip { get; init; }

	/// <summary> Freebox Server name </summary>
	public   string? name { get; init; }
	/// <summary> Freebox Server DNS name </summary>
	public   string? name_dns { get; init; }

	/// <summary> Freebox Server mDNS name </summary>
	public   string? name_mdns { get; init; }
	/// <summary>  Freebox Server netbios name</summary>
	public   string? name_netbios { get; init; }
	/// <summary> LAN mode  </summary>
	/// <remarks>In bridge mode, most of Freebox services are disabled. It is recommended to use the router mode, and third party apps should not change this setting</remarks>
	public lanMode? mode { get; init; }




}
