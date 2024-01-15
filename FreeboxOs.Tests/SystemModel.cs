// // <copyright>
// // Copyright (c) Frederic Wauquier rights reserved.
// // <author > Frederic Wauquier</author >
// // </copyright >
//
// namespace FreeboxOs;
//
// public sealed class SystemModel : JsonModel {
//
//
// 	public required int customer_hdd_slots { get; init; } 
// 	public required string net_operator { get; init; }
//  
// 	public required Language[] supported_languages { get; init; }
// 	public required bool has_dsl { get; init; }             
// 	public required bool has_dect { get; init; }
// 	// TODO : Convert to Enum
// 	public required Country wifi_country { get; init; }     
// 	public required bool has_home_automation { get; init; }
// 	// TODO : Convert to Enum
// 	public required string wifi_type { get; init; }      
// 	public required string pretty_name { get; init; }
// 	public required bool has_lan_sfp { get; init; }
// 	public required string name { get; init; }
// 	public required bool has_separate_internal_storage { get; init; }
// 	public required int internal_hdd_size { get; init; }
// 		 
// 	public required Language default_language { get; init; } 
// 	public required bool has_vm { get; init; }
// 	public required bool has_expansions { get; init; }  
// }
//
// public sealed class System : JsonModel {
// 	public required string mac { get; init; }
// 	public required SystemModel model_info { get; init; }
// 	public required string board_name { get; init; }
// 	public required string disk_status { get; init; }
// 	public required string uptime { get; init; }
// 	[JsonConverter(typeof(TimeSpanConverter))]
// 	public required TimeSpan uptime_val { get; init; }
// 	public required string user_main_storage { get; init; }
// 	public required bool box_authenticated { get; init; }
// 	public required string serial { get; init; }
// 	public required string firmware_version { get; init; }
//
// 	public required SystemExpensions[] expansions { get; init; }
//
// 	public required SystemSensors[] sensors { get; init; }
// 	public required SystemSensors[] fans { get; init; }
//
// }
// public sealed class SystemExpensions : JsonModel {
// 	// TODO : Convert to Enum
// 	public required string type { get; init; }     // "unknown",
// 	public required bool present { get; init; }    // false,
// 	public required int slot { get; init; }        // 1,
// 	public required bool probe_done { get; init; } // true,
// 	public required bool supported { get; init; }  // false,
// 	public required string bundle { get; init; }   // ""
// }
// public sealed class SystemSensors : JsonModel {
// 	public required string id { get; init; }
// 	public required string name { get; init; }
// 	public required int value { get; init; }
// }
