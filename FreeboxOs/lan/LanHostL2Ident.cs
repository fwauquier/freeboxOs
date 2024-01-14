// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.lan;

public sealed class LanHostL2Ident:JsonModel {
	/// <summary> Layer 2 id </summary>
	public required string id  { get; init; }
	/// <summary> Type of layer 2 address </summary>
	public required LanHostL2IdentType type { get; init; }

}
