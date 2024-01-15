// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >
using FreeboxOs.storage;

namespace FreeboxOs;

public sealed partial class Api {
	public async Task<Disk[]?> StorageDisk() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<Disk[]>("storage/disk").ConfigureAwait(false);
	}
}
