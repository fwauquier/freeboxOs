// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.login;

public sealed class TokenRequest:JsonModel {
	/// <summary>A unique app_id string</summary>
	public string app_id { get; init; } = "FWA_FreeboxOs";

	/// <summary>A descriptive application name (will be displayed on lcd)</summary>
	public string app_name { get; init; } = "FWA_FreeboxOs";

	/// <summary>app version</summary>
	public string app_version { get; init; } = "1.0.0";

	/// <summary>The name of the device on which the app will be used</summary>
	public string device_name { get; init; } = Environment.MachineName;


}
