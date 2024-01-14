// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class BssConfig : JsonModel {
	public bool? enabled { get; init; }
	public bool? wps_enabled { get; init; }
	public BssEncryption? encryption { get; init; }
	public bool? hide_ssid { get; init; }
	public int? eapol_version { get; init; }
	public string? key { get; init; }
	public string? wps_uuid { get; init; }
	public bool? use_default_config { get; init; }
	public string? issidd { get; init; }
}
