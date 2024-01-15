// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class AccessPointStatus : JsonModel {
	public string? channel_width { get; set; }        
	public int? primary_channel { get; set; }      
	public bool? dfs_disabled { get; set; }         
	public int? dfs_cac_remaining_time { get; set; } 
	public int? secondary_channel { get; set; }      
	public string? state { get; set; }               
}
