// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs;

public sealed class LoginInfo : JsonModel
{
	[JsonPropertyName("password_salt")] public required string PasswordSalt { get; init; }


    /// <summary>Status of authorization request </summary>
    [JsonPropertyName("status")] public LoginInfoStatus status { get; init; }

    [JsonPropertyName("challenge")] public required string[] Challenge { get; init; }
    [JsonPropertyName("logged_in")] public bool? logged_in { get; init; }
    [JsonPropertyName("password_set")] public bool? password_set { get; init; }

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
