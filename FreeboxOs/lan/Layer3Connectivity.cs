// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.lan;

public sealed class Layer3Connectivity:JsonModel {
	/// <summary> Layer 3 address </summary>
	public required string addr   { get; init; }
	/// <summary> address Type ipv4 or ipv6 </summary>
	// TODO convert to Enum
	public required string af  { get; init; }
	/// <summary> is the connection active</summary>
	public bool active    { get; init; }
	/// <summary>is the connection reachable </summary>
	public bool reachable    { get; init; }
	/// <summary>last activity timestamp </summary>
	public long  last_activity   { get; init; }
	/// <summary>last reachable timestamp </summary>
	public long  last_time_reachable    { get; init; }


}
