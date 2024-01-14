// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using System.Buffers.Text;
using System.Buffers;
using System.Diagnostics;
using FreeboxOs.lan;

namespace FreeboxOs.dhcp;

/// <summary>
/// A Dynamic DHCP lease
/// </summary>
public sealed class DhcpDynamicLease : JsonModel {
/// <summary> Host mac address  </summary>
	public string? mac { get; init; }
	/// <summary>  hostname matching the mac address </summary>
	public string? hostname { get; init; }
	/// <summary> IPv4 to assign to the host  </summary>
	public string? ip { get; init; }

	/// <summary>
	/// time left before lease needs to be refreshed
	/// </summary>
	[JsonConverter(typeof(TimeSpanConverter))]
	public TimeSpan lease_remaining { get; init; }

	/// <summary>
	/// timestamp of the lease first assignment
	/// </summary>
	[JsonConverter(typeof(DateTimeConverter))]

	public DateTime assign_time { get; init; }

	/// <summary>
	/// timestamp of the last lease refresh
	/// </summary>
	[JsonConverter(typeof(DateTimeConverter))]
	public DateTime refresh_time { get; init; }

	/// <summary>is the lease static  </summary>
	public bool is_static { get; set; }
 
	/// <summary>   </summary>
	public LanHost? host { get; init; } 
}
