// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum hostType {

	/// <summary>Workstation </summary>
	workstation,

	/// <summary>Laptop </summary>
	laptop,

	/// <summary>Smartphone </summary>
	smartphone,

	/// <summary>Tablet</summary>
	tablet,

	/// <summary>Printer </summary>
	printer,

	/// <summary>Video game console </summary>
	vg_console,

	/// <summary>TV </summary>
	television,

	/// <summary>Nas </summary>
	nas,

	/// <summary>IP Camera </summary>
	ip_camera,

	/// <summary>IP Phone </summary>
	ip_phone,

	/// <summary>Freebox Player </summary>
	freebox_player,

	/// <summary>Freebox Server </summary>
	freebox_hd,

	/// <summary>Networking device </summary>
	networking_device,

	/// <summary>Multimedia device </summary>
	multimedia_device,

	/// <summary>Other </summary>
	other,

	/// <summary>freebox_delta</summary>
	freebox_delta,

	/// <summary>freebox_wifi</summary>
	freebox_wifi,
}
