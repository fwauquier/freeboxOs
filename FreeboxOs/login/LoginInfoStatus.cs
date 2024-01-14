// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs;

/// <summary>
/// Status of authorization request
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LoginInfoStatus {
	/// <summary>unknown: the app_token is invalid or has been revoked</summary>
	unknown,
	/// <summary>pending: the user has not confirmed the authorization request yet</summary>
	pending,
	/// <summary>timeout: the user did not confirmed the authorization within the given time</summary>
	timeout,
	/// <summary>granted: the app_token is valid and can be used to open a session</summary>
	granted,
	/// <summary>denied:	the user denied the authorization request</summary>
	denied
}
