// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status {
	enabled,
	disabled
}
