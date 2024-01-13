// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using System.Net;
using System.Security.Cryptography;
using System.Text;
using FreeboxOs.Models;
using Jint;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;

sealed partial class Api {
	public async Task<LoginInfo> Login() {
		if (m_LongInfo is not null) return m_LongInfo;
		Logger?.LogDebug("LoginAsync - login/ Get");
		var loginGet = await GetAsync<LoginInfo>("login");
		var challenge = string.Empty;

		var engine = new Engine();
		engine.SetValue("unescape", WebUtility.UrlDecode);
		challenge = loginGet.Challenge.Aggregate(challenge, (current, challengeEntry) => current + engine.Execute(challengeEntry).GetCompletionValue());
		var password = ObfuscatePassword(_password, challenge,loginGet.PasswordSalt );

		Logger?.LogDebug("LoginAsync - login/ Post");
		var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("password", password) });
		m_LongInfo= await PostAsync<LoginInfo>("login", content).ConfigureAwait(false);
		return m_LongInfo;
	}

	private string ObfuscatePassword(string password, string challenge, string salt) {
		Logger?.LogTrace("ObfuscatePassword-Password:{Password} Challenge:{Challenge} Salt:{Salt}", password, challenge, salt);
		using var sha1 = SHA1.Create();
		var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
		using var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(ByteArrayToHexadecimalString(hash)));
		var obfuscatePassword = ByteArrayToHexadecimalString(hmac.ComputeHash(Encoding.UTF8.GetBytes(challenge)));
		Logger?.LogTrace("ObfuscatePassword-Result:{ObfuscatePassword}", obfuscatePassword);
		return obfuscatePassword;

		static string ByteArrayToHexadecimalString(IEnumerable<byte> byteArray) {
			return string.Join("", byteArray.Select(b => b.ToString("x2")));
		}
	}

	public bool IsLoggedIn => m_LongInfo is not null;

	private LoginInfo? m_LongInfo;
	private async Task EnsureLoginAsync() {
		if(m_LongInfo is not null) return;
		m_LongInfo = await Login().ConfigureAwait(false);
	}

	private async Task EnsureLogOffAsync() {
		await Logout();
	}

	public async Task Logout() {
		if(m_LongInfo is null) return;
		var result=await PostAsync( "login/logout",null).ConfigureAwait(false);
		m_LongInfo = null;
	}

	public sealed class TokenRequest:JsonModel {
		/// <summary>A unique app_id string</summary>
		public string app_id { get; init; } = "FWA_FreeboxOs";

		/// <summary>A descriptive application name (will be displayed on lcd)</summary>
		public string app_name { get; init; } = "FWA_FreeboxOs";

		/// <summary>app version</summary>
		public string app_version { get; init; } = "1.0.0";

		/// <summary>The name of the device on which the app will be used</summary>
		public string device_name { get; init; } = Environment.MachineName;


	}

	public sealed class TokenResponse:JsonModel {
		/// <summary> </summary>
		public string app_token { get; init; }

		/// <summary> </summary>
		public int track_id { get; init; }


	}

	public sealed class LoginInfo : JsonModel {
		[JsonPropertyName("password_salt")] public string? PasswordSalt { get; init; }


		/// <summary>
		///     <ul>
		///         <li>unknown: the app_token is invalid or has been revoked</li>
		///         <li>pending: the user has not confirmed the authorization request yet</li>
		///         <li>timeout: the user did not confirmed the authorization within the given time</li>
		///         <li>granted: the app_token is valid and can be used to open a session</li>
		///         <li>denied:	the user denied the authorization request</li>
		///     </ul>
		/// </summary>
		public string status { get; init; }

		[JsonPropertyName("challenge")] public string[]? Challenge { get; init; }

		public void EnsureAuthorized() {
			switch (status) {
				case "granted": break;
				default:
					throw new ApiException($"Application not authorized yet. Actual status is '{status}'.");
			}
		}


	}

	public sealed class SessionStart :JsonModel {
		/// <summary>
		/// Same app_id used in TokenRequest to get the app_token
		/// </summary>
		public string app_id  { get; init; }
		/// <summary>
		/// app version
		/// </summary>
		public string app_version   { get; init; }
		/// <summary>
		/// The password computed using the challenge and the app_token<br/>
		/// To compute the password you have to compute the hmac-sha1 of the challenge and the app_token<br/>
		/// password = hmac-sha1(app_token, challenge)
		/// </summary>
		public string password { get; init; }


		/// <summary>
		///     <ul>
		///         <li>unknown: the app_token is invalid or has been revoked</li>
		///         <li>pending: the user has not confirmed the authorization request yet</li>
		///         <li>timeout: the user did not confirmed the authorization within the given time</li>
		///         <li>granted: the app_token is valid and can be used to open a session</li>
		///         <li>denied:	the user denied the authorization request</li>
		///     </ul>
		/// </summary>
		public string status { get; init; }

		[JsonPropertyName("challenge")] public string[]? Challenge { get; init; }

		public void EnsureAuthorized() {
			switch (status) {
				case "granted": break;
				default:
					throw new ApiException($"Application not authorized yet. Actual status is '{status}'.");
			}
		}


	}
}
