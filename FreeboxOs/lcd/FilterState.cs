// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.lcd;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FilterState {
	/// <summary>
	/// 	access is allowed
	/// </summary>
	allowed,
	/// <summary>
	/// 	access is denied
	/// </summary>
	denied,
	/// <summary>
	/// access is granted only for HTTP and HTTPS traffic
	/// </summary>
	webonly
}
