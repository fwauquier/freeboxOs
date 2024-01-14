// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class Config : JsonModel {
	public required bool enabled { get; set; }
	public required Physical[] expected_phys { get; set; }
	public required Status mac_filter_state { get; set; }
}
