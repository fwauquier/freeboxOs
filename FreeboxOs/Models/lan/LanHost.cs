// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public sealed class LanHost:JsonModel {
	public AccessPoint? access_point  { get; init; }
	public NetworkControl? network_control  { get; init; }

	public string? @interface  { get; init; }
	public string? @default_name  { get; init; }
	public long? @first_activity  { get; init; }
	public string? @model  { get; init; }


	/// <summary> Host id (unique on this interface) </summary>
	public string id  { get; init; }
	/// <summary> Host primary name (chosen from the list of available names, or manually set by user) </summary>
	public string primary_name  { get; set; }
	/// <summary>When possible, the Freebox will try to guess the host_type, but you can manually override this to the correct value.</summary>
	public hostType  host_type   { get; set; }
	/// <summary> If true the primary name has been set manually</summary>
	public bool primary_name_manual     { get; init; }
	/// <summary> Layer 2 network id and its type</summary>
	public LanHostL2Ident  l2ident   { get; init; }
	/// <summary>Host vendor name (from the mac address) </summary>
	public string  vendor_name   { get; init; }
	/// <summary> If true the host is always shown even if it has not been active since the Freebox startup</summary>
	public bool persistent    { get; set; }
	/// <summary>If true the host can receive traffic from the Freebox </summary>
	public bool  reachable  { get; init; }
	/// <summary> Last time the host was reached</summary>
	public long  last_time_reachable   { get; init; }
	/// <summary>If true the host sends traffic to the Freebox </summary>
	public bool active     { get; init; }
	/// <summary> Last time the host sent traffic</summary>
	public long  last_activity   { get; init; }
	/// <summary> List of available names, and their source</summary>
	public LanHostName[]?  names  { get; init; }
	/// <summary> List of available layer 3 network connections</summary>
	public LanHostL3Connectivity[]? l3connectivities    { get; init; }

}