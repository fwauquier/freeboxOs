// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs;

public sealed class SessionStart : JsonModel
{
	/// <summary>
	/// Same app_id used in TokenRequest to get the app_token
	/// </summary>
	public required string app_id { get; init; }
	/// <summary>
	/// app version
	/// </summary>
	public required string app_version { get; init; }
	/// <summary>
	/// The password computed using the challenge and the app_token<br/>
	/// To compute the password you have to compute the hmac-sha1 of the challenge and the app_token<br/>
	/// password = hmac-sha1(app_token, challenge)
	/// </summary>
	public required string password { get; init; }


	/// <summary>
    /// Status of authorization request
    /// </summary>
	public required LoginInfoStatus status { get; init; }

	[JsonPropertyName("challenge")] public string[]? Challenge { get; init; }

	public void EnsureAuthorized()
	{
		switch (status)
		{
			case LoginInfoStatus.granted: break;

            case LoginInfoStatus.unknown:
			case LoginInfoStatus.pending:
			case LoginInfoStatus.timeout:
			case LoginInfoStatus.denied:
			default:
				throw new ApiException($"Application not authorized yet. Actual status is '{status}'.");
		}
	}


}
