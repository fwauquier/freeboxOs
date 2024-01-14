// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class Physical {
	public required string band { get; set; }
	public required int phy_id { get; set; }
	public required bool detected { get; set; }

}
