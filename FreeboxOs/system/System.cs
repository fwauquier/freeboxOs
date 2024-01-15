// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.system;

public sealed class System : JsonModel {
	public required string mac { get; init; }
	public required Model model_info { get; init; }
	public required string board_name { get; init; }
	public required string disk_status { get; init; }
	public required string uptime { get; init; }
	[JsonConverter(typeof(TimeSpanConverter))]
	public required TimeSpan uptime_val { get; init; }
	public required string user_main_storage { get; init; }
	public required bool box_authenticated { get; init; }
	public required string serial { get; init; }
	public required string firmware_version { get; init; }

	public required Expansions[] expansions { get; init; }

	public required Sensors[] sensors { get; init; }
	public required Sensors[] fans { get; init; }

}
