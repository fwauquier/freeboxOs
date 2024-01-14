// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using FreeboxOs.dhcp; 

namespace FreeboxOs;

// https://dev.freebox.fr/sdk/os/dhcp/
public sealed partial class Api {
	/// <summary>
	///  Get the current DHCP configuration
	/// </summary>
	/// <returns></returns>
	public async Task<DhcpConfig?> DhcpConfig() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<DhcpConfig>("dhcp/config").ConfigureAwait(false);
	}
	// TODO Implement Update the current DHCP configuration
	// TODO Implement Add a DHCP static lease
	// TODO Implement Update DHCP static lease
	// TODO Implement Delete a DHCP static lease

	/// <summary>
	///  You can get the list of <see cref="DhcpStaticLease"/> using this API
	/// </summary>
	/// <returns></returns>
	public async Task<DhcpStaticLease[]?> DhcpStaticLease() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<DhcpStaticLease[]>("dhcp/static_lease").ConfigureAwait(false);
	}

	/// <summary>
	///  You can get the list of <see cref="DhcpDynamicLease"/> using this API
	/// </summary>
	/// <returns></returns>
	public async Task<DhcpDynamicLease[]?> DhcpDynamicLease() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<DhcpDynamicLease[]>("dhcp/dynamic_lease").ConfigureAwait(false);
	}
}
