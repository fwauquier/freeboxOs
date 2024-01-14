// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class BssStatus : JsonModel {
	public string? state { get; init; }             //": "active",
	public int? authorized_sta_count { get; init; } //": 2,
	public int? sta_count { get; init; }            //": 2,
	public string? band { get; init; }              //": "5G",
	public bool? is_main_bss { get; init; }         //": false
}
