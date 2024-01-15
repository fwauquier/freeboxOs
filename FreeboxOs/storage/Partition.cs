// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.storage;

public sealed class Partition : JsonModel {

	// TODO Convert to enum
	public required string fstype{ get; set; }
	public required long total_bytes { get; set; } 
	public required string label{ get; set; } 
	public required int id { get; set; }
	[JsonPropertyName("internal")]
	public required bool isInternal { get; set; } // false,
	// TODO Convert to enum
	public required string fsck_result{ get; set; }
	// TODO Convert to enum
	public required string state{ get; set; } 
	public required int disk_id { get; set; }   
	public required long free_bytes { get; set; } 
	public required long used_bytes { get; set; } 
	public required string path{ get; set; }
}
