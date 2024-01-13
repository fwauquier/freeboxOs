// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public sealed class LanHostL3Connectivity:JsonModel {
	/// <summary> Layer 3 address </summary>
	public string addr   { get; init; }
	/// <summary> address Type ipv4 or ipv6 </summary>
	public string af  { get; init; }
	/// <summary> is the connection active</summary>
	public bool active    { get; init; }
	/// <summary>is the connection reachable </summary>
	public bool reachable    { get; init; }
	/// <summary>last activity timestamp </summary>
	public long  last_activity   { get; init; }
	/// <summary>last reachable timestamp </summary>
	public long  last_time_reachable    { get; init; }


}
