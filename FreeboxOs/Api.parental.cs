// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lcd;

namespace FreeboxOs;

// https://dev.freebox.fr/sdk/os/parental/
public sealed partial class Api {
	/// <summary>
	///     Get parental filter config
	/// </summary>
	/// <returns></returns>
	public async Task<Config?> ParentalConfig() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<Config>("parental/config").ConfigureAwait(false);
	}

	/// <summary>
	/// Retrieve all Parental Filter rules
	/// </summary>
	/// <returns></returns>
	public async Task<ParentalFilter[]?> ParentalFilters() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<ParentalFilter[]>("parental/filter").ConfigureAwait(false);
	}
}
