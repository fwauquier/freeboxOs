// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class ApStatus : JsonModel {
	public string? channel_width { get; set; }       // "40",
	public int? primary_channel { get; set; }        // 6,
	public bool? dfs_disabled { get; set; }          // false,
	public int? dfs_cac_remaining_time { get; set; } // 0,
	public int? secondary_channel { get; set; }      // 10,
	public string? state { get; set; }               // "active"
}
