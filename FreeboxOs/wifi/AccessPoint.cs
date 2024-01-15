// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class AccessPoint : JsonModel {
	public required AccessPointCapabilities capabilities { get; set; }
	public required string name { get; set; }
	public required int id { get; set; }
	public required AccessPointConfig config { get; set; }
	public required AccessPointStatus status { get; set; }
}
