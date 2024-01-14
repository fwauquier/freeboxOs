// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lan;

namespace FreeboxOs.network_control;
public sealed class NetworkControl : JsonModel {
	public NetworkControlMode override_mode { get; init; }
	public   int profile_id { get; init; }

	//public string? override_mode { get; init; }
	public required LanHost[] hosts { get; init; }

	public DayRange[]? cdayranges { get; init; }
	public int resolution { get; init; }
	public required string profile_name { get; init; }
	public NetworkControlMode current_mode { get; init; }
	public string[]? macs { get; init; }

	/// <summary>
	/// Date/Time of next mode change
	/// </summary>

	[JsonConverter(typeof(NullableDateTimeConverter))]

	public DateTime? next_change { get; init; }
	[JsonPropertyName("override")]
	public bool @override { get; init; }

	public NetworkControlMode rule_mode { get; init; }
	public string? profile_icon { get; init; }
}
