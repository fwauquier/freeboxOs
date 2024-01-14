// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using FreeboxOs.network_control;

namespace FreeboxOs.lan;

public sealed class LanNetworkControl : JsonModel {
	public   NetworkControlMode current_mode { get; init; }
	public    NetworkControlMode? rule_mode { get; init; }
		public required int profile_id  { get; init; }
		public  required string name  { get; init; }
	//	public string? override_mode { get; init; }
	//	public LanHost[]? hosts { get; init; }
	//	public   string? profile_name { get; init; }
	//	public   int? resolution { get; init; }
	//	public string[]? macs { get; init; }
	//	public string? profile_icon { get; init; }

	//	public int? next_change { get; init; }

	///// <summary>
	///// Is the rule mode has been overrided by the current mode
	///// </summary>
	//[JsonPropertyName("override")]
	//	public   bool? overrided { get; init; }

	//public DayRange[]? cdayranges { get; init; }
	}
