// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using System.Net;
using System.Security.Cryptography;
using System.Text;
using Jint;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;

// https://dev.freebox.fr/sdk/os/login/
public sealed partial class Api {
	public async Task<LoginInfo?> Login() {
		if (m_LongInfo is not null) return m_LongInfo;
		Logger?.LogDebug("LoginAsync - login/ Get");
		var loginGet = await GetAsync<LoginInfo>("login").ConfigureAwait(false) ?? throw new ApiException("Cannot get initial login information. [GET /api/v4/login/ HTTP/1.1]");
		var challenge = string.Empty;

		var engine = new Engine();
		engine.SetValue("unescape", WebUtility.UrlDecode);
		challenge = loginGet.Challenge.Aggregate(challenge, (current, challengeEntry) => current + engine.Execute(challengeEntry).GetCompletionValue());
		var password = ObfuscatePassword(_password, challenge, loginGet.PasswordSalt);

		Logger?.LogDebug("LoginAsync - login/ Post");
		using var content = new FormUrlEncodedContent(new[] {new KeyValuePair<string, string>("password", password)});
		m_LongInfo = await PostAsync<LoginInfo>("login", content).ConfigureAwait(false);
		return m_LongInfo;
	}

	private string ObfuscatePassword(string password, string challenge, string salt) {
#pragma warning disable CA1850 // Prefer static 'HashData' method over 'ComputeHash'
#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
		Logger?.LogTrace("ObfuscatePassword-Password:{Password} Challenge:{Challenge} Salt:{Salt}", password, challenge, salt);
		using var sha1              = SHA1.Create();
		var       hash              = sha1.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
		using var hmac              = new HMACSHA1(Encoding.UTF8.GetBytes(ByteArrayToHexadecimalString(hash)));
		var       obfuscatePassword = ByteArrayToHexadecimalString(hmac.ComputeHash(Encoding.UTF8.GetBytes(challenge)));
		Logger?.LogTrace("ObfuscatePassword-Result:{ObfuscatePassword}", obfuscatePassword);
		return obfuscatePassword;
#pragma warning restore CA5350 // Do Not Use Weak Cryptographic Algorithms
#pragma warning restore CA1850 // Prefer static 'HashData' method over 'ComputeHash'

		static string ByteArrayToHexadecimalString(IEnumerable<byte> byteArray) {
			return string.Join("", byteArray.Select(b => b.ToString("x2")));
		}
	}

	public bool IsLoggedIn => m_LongInfo is not null;

	private LoginInfo? m_LongInfo;

	private async Task EnsureLoginAsync() {
		if (m_LongInfo is not null) return;
		m_LongInfo = await Login().ConfigureAwait(false);
	}

	private async Task EnsureLogOffAsync() {
		await Logout().ConfigureAwait(false);
	}

	public async Task Logout() {
		if (m_LongInfo is null) return;
		  _ = await PostAsync("login/logout", null).ConfigureAwait(false);
		m_LongInfo = null;
	}
}

