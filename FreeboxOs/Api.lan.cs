// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs;

sealed partial class Api {
	/// <summary>
	/// Getting the list of browsable LAN interfaces
	/// </summary>
	/// <returns></returns>
	public async Task<LanBrowserInterface[]> LanBrowserInterfacesAsync() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LanBrowserInterface[]>("lan/browser/interfaces/").ConfigureAwait(false);
	}

	/// <summary>
	/// Returns the list of LanHost on this interface
	/// </summary>
	/// <returns></returns>
	public async Task<LanHost[]?> LanBrowserHostAsync(string @interface) {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LanHost[]>("lan/browser/"+@interface+"/").ConfigureAwait(false);
	}
}
