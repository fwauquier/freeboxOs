// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using FreeboxOs.lan;

namespace FreeboxOs;

// https: //dev.freebox.fr/sdk/os/lan/#lan-browser
public sealed partial class Api {
	/// <summary>
	/// Getting the list of browsable LAN interfaces
	/// </summary>
	/// <returns></returns>
	public async Task<LanBrowserInterface[]?> LanBrowserInterfacesAsync() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LanBrowserInterface[]>("lan/browser/interfaces").ConfigureAwait(false);
	}

	/// <summary>
	/// Returns the list of LanHost on this interface
	/// </summary>
	/// <returns></returns>
	public async Task<LanHost[]?> LanBrowserHostAsync(string @interface) {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LanHost[]>("lan/browser/"+@interface).ConfigureAwait(false);
	}

    /// <summary>
    /// Get the current Lan configuration
    /// </summary>
    public async Task<LanConfig?> GetLanConfiguration()
	{
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LanConfig>("lan/config").ConfigureAwait(false);
	}

    }
