// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NetworkControlMode {
	denied=0,
	allowed=1,
}
