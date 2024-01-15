// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.system;

public sealed class Sensors : JsonModel {
	public required string id { get; init; }
	public required string name { get; init; }
	public required int value { get; init; }
}
