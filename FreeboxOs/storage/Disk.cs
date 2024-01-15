// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.storage;

public sealed class Disk : JsonModel {
	public   int? dle_duration{ get; set; }       
	public required int read_error_requests{ get; set; }  
	public required int read_requests{ get; set; }       
	public required bool spinning { get; set; }        
	public required string table_type{ get; set; }  
	public required string firmware{ get; set; }  
	public required string type{ get; set; } 
	public required bool idle { get; set; }  
	public required int connector { get; set; }            
	public required int id { get; set; }                   
	public required int write_error_requests { get; set; }
// TODO Convert to enum
	public required string state{ get; set; }        
	public required int write_requests { get; set; }   
	public required long total_bytes { get; set; }
	public required string model{ get; set; }
	[JsonConverter(typeof(TimeSpanConverter))]
	public   TimeSpan? active_duration { get; set; }
	[JsonConverter(typeof(TimeSpanConverter))]
	public   TimeSpan? idle_duration { get; set; }
	public required int temp { get; set; }
	public required string serial { get; set; }                          
	public required Partition[] partitions { get; init; }
}
