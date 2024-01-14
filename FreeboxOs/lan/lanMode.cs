// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.lan;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum lanMode {
	/// <summary>
	/// The Freebox acts as a network router
	/// </summary>
	router,
	/// <summary>
	/// The Freebox acts as a network bridge
	/// </summary>
	bridge
}
