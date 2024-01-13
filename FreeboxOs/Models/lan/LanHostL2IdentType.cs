// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LanHostL2IdentType{
	/// <summary>mac_address</summary>
	mac_address,
}
