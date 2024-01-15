// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs;

public sealed partial class Api {
	public async Task<system.System?> System() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<system.System>("system").ConfigureAwait(false);
	}
}
