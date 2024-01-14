// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.network_control;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NetworkControlMode {
	denied = 0,
	allowed = 1,
}
