// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.network_control;

namespace FreeboxOs;

public sealed partial class Api {
	public async Task<NetworkControl[]?> GetProfiles() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<network_control.NetworkControl[]>("network_control").ConfigureAwait(false); 
	}
 

}
