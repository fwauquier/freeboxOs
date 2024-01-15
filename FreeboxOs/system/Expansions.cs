// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.system;

public sealed class Expansions : JsonModel {
	// TODO : Convert to Enum
	public required string type { get; init; }     // "unknown",
	public required bool present { get; init; }    // false,
	public required int slot { get; init; }        // 1,
	public required bool probe_done { get; init; } // true,
	public required bool supported { get; init; }  // false,
	public required string bundle { get; init; }   // ""
}
