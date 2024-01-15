// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lan;

namespace FreeboxOs.wifi;

public sealed class MacFilter : JsonModel {
	public required string mac { get; set; }
	public required string type { get; set; }
	public required string comment { get; set; }
	public required string hostname { get; set; }
	public required string id { get; set; }
	public required Host host { get; set; }
}
