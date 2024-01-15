// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using FreeboxOs.network_control;

namespace FreeboxOs.lan;

public sealed class Host:JsonModel {
	public AccessPoint? access_point  { get; init; }
	public NetworkControl? network_control  { get; init; }

	public string? @interface  { get; init; }
	public string? @default_name  { get; init; }
	[JsonConverter(typeof(DateTimeConverter))]
	public DateTime @first_activity  { get; init; }
	public string? @model  { get; init; }


	/// <summary> Host id (unique on this interface) </summary>
	public required string id  { get; init; }
	/// <summary> Host primary name (chosen from the list of available names, or manually set by user) </summary>
	public  string? primary_name  { get; set; }
	/// <summary>When possible, the Freebox will try to guess the host_type, but you can manually override this to the correct value.</summary>
	public HostType  host_type   { get; set; }
	/// <summary> If true the primary name has been set manually</summary>
	[JsonConverter(typeof(NullableBoolConverter))]
	public bool? primary_name_manual     { get; init; }
	/// <summary> Layer 2 network id and its type</summary>
	public Layer2Identifier?  l2ident   { get; init; }
	/// <summary>Host vendor name (from the mac address) </summary>
	public string?  vendor_name   { get; init; }
	/// <summary> If true the host is always shown even if it has not been active since the Freebox startup</summary>
	public bool persistent    { get; set; }
	/// <summary>If true the host can receive traffic from the Freebox </summary>
	public bool  reachable  { get; init; }
	/// <summary> Last time the host was reached</summary>
	[JsonConverter(typeof(DateTimeConverter))]
	public DateTime  last_time_reachable   { get; init; }
	/// <summary>If true the host sends traffic to the Freebox </summary>
	public bool active     { get; init; }
	/// <summary> Last time the host sent traffic</summary>
	[JsonConverter(typeof(DateTimeConverter))]
	public DateTime  last_activity   { get; init; }
	/// <summary> List of available names, and their source</summary>
	public HostName[]?  names  { get; init; }
	/// <summary> List of available layer 3 network connections</summary>
	public Layer3Connectivity[]? l3connectivities    { get; init; }

}
