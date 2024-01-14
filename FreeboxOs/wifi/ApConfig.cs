// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class ApConfig : JsonModel {
	public required string? channel_width { get; set; }
	public required string? band { get; set; }
	public required ApConfigHt ht { get; set; }
	public required bool dfs_enabled { get; set; }
	public required int secondary_channel { get; set; }
	public required ApConfigHe he { get; set; }
	public required int primary_channel { get; set; }
}
