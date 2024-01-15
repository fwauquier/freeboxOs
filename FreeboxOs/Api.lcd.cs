// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using FreeboxOs.parental;

namespace FreeboxOs;

// https://dev.freebox.fr/sdk/os/dhcp/
public sealed partial class Api {
	/// <summary>
	/// Get the current LCD configuration
	/// </summary>
	/// <returns></returns>
	public async Task<LcdConfig?> LcdConfig() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LcdConfig>("lcd/config").ConfigureAwait(false);
	}
	// TODO Implement Update LCD configuration
}
