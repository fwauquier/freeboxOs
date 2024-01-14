// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.wifi; 
namespace FreeboxOs;

public sealed partial class Api {
	public async Task<Bss[]?> WifiBss() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<Bss[]>("wifi/bss").ConfigureAwait(false);
	}
	public async Task<Config?> WifiConfig() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<Config>("wifi/config").ConfigureAwait(false);
	}
	 
}
