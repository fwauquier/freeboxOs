// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.wifi; 
namespace FreeboxOs;

public sealed partial class Api {
	/// <summary>
	/// Get List of WiFi private networks configured on the Freebox
	/// </summary>
	/// <returns></returns>
	public async Task<Bss[]?> WifiBss() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<Bss[]>("wifi/bss").ConfigureAwait(false);
	}

	/// <summary>
	/// Get WiFi configuration
	/// </summary>
	/// <returns></returns>
	public async Task<Config?> WifiConfig() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<Config>("wifi/config").ConfigureAwait(false);
	}

	/// <summary>
	/// Get all WiFi access points
	/// </summary>
	/// <returns></returns>
	public async Task<AccessPoint[]?> WifiAccessPoint() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<AccessPoint[]>("wifi/ap").ConfigureAwait(false);
	}

	/// <summary>
	/// Get details of a specific WiFi access point
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task<AccessPoint?> WifiAccessPoint(int id) {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<AccessPoint>($"wifi/ap/{id}").ConfigureAwait(false);
	}

	/// <summary>
	/// Get list of whitelisted/blacklisted WiFi stations
	/// </summary>
	/// <returns></returns>
	public async Task<MacFilter[]?> WifiMacFilter() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<MacFilter[]>("wifi/mac_filter").ConfigureAwait(false);
	}

	// TODO Implement Update WiFi mac filter
	// POST http: //192.168.0.254/api/latest/wifi/mac_filter/?_dc=1705301707020
	// {
	//     "id": "",
	//     "mac": "C4:9D:ED:08:0D:09",
	//     "hostname": "",
	//     "comment": "Commentaire",
	//     "type": "whitelist",
	//     "host": ""
	// }

	/// <summary>
	/// Get list of <see cref="Station"/> for a specific access point
	/// </summary>
	/// <param name="accessPointId">id of a <see cref="AccessPoint"/></param>
	/// <returns></returns>
	public async Task<Station[]?> Stations(int accessPointId) {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<Station[]>($"wifi/ap/{accessPointId}/stations").ConfigureAwait(false);
	}
	

}
