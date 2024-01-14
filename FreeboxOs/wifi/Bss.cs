// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class Bss : JsonModel {
	public required BssConfig config { get; init; }
	public BssParams? bss_params { get; init; }
	public BssParams? shared_bss_params { get; init; }
	public string? id { get; init; }
	public bool use_shared_params { get; init; }
	public int phy_id { get; init; }
	public required BssStatus  status { get; init; }
}

