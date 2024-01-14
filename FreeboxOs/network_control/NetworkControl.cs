// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lan;

namespace FreeboxOs.network_control;
public sealed class NetworkControl : JsonModel {
	public string? override_mode { get; init; }
	public   int profile_id { get; init; }

	//public string? override_mode { get; init; }
	public LanHost[]? hosts { get; init; }

	public DayRange[]? cdayranges { get; init; }
	public int resolution { get; init; }
	public string? profile_name { get; init; }
	public ProfileMode current_mode { get; init; }
	public string[]? macs { get; init; }
	[JsonConverter(typeof(DateTimeConverter))]

	public DateTime next_change { get; init; }
	[JsonPropertyName("override")]
	public bool @override { get; init; }

	public   ProfileMode rule_mode { get; init; }
	public string? profile_icon { get; init; }
}
