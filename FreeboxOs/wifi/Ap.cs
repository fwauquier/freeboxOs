// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class Ap : JsonModel {
	public required ApCapabilities capabilities { get; set; }
	public required string name { get; set; }
	public required int id { get; set; }
	public required ApConfig config { get; set; }
	public required ApStatus status { get; set; }
}
