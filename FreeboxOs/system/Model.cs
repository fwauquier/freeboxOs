// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.system;

public sealed class Model : JsonModel {


	public required int customer_hdd_slots { get; init; } 
	public required string net_operator { get; init; }
 
	public required Language[] supported_languages { get; init; }
	public required bool has_dsl { get; init; }             
	public required bool has_dect { get; init; }
	// TODO : Convert to Enum
	public required Country wifi_country { get; init; }     
	public required bool has_home_automation { get; init; }
	// TODO : Convert to Enum
	public required string wifi_type { get; init; }      
	public required string pretty_name { get; init; }
	public required bool has_lan_sfp { get; init; }
	public required string name { get; init; }
	public required bool has_separate_internal_storage { get; init; }
	public required int internal_hdd_size { get; init; }
		 
	public required Language default_language { get; init; } 
	public required bool has_vm { get; init; }
	public required bool has_expansions { get; init; }  
}
