// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using FreeboxOs.connection; 

namespace FreeboxOs;

// https://dev.freebox.fr/sdk/os/dhcp/
public sealed partial class Api {
	/// <summary>
	///  Get the current DHCP configuration
	/// </summary>
	/// <returns></returns>
	public async Task<Config?> ConnectionConfig() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<Config>("connection/config").ConfigureAwait(false);
	}
}
