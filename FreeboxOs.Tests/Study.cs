// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using System.Net.NetworkInformation;
using FreeboxOs.lan;
using FreeboxOs.wifi;

namespace FreeboxOs;

[TestClass]
public class Study {
	public TestContext TestContext { get; set; } = null!;


	[TestMethod]
	public async Task network_control() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<NetworkControl[]>("network_control").ConfigureAwait(false);
		result.Dump(TestContext);
	}

	

	[TestMethod]
	public async Task mac_filter() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("wifi/mac_filter").ConfigureAwait(false);
		result.Dump(TestContext);
	}
	[TestMethod]
	public async Task lan_browser_pub() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<LanHost[]>("lan/browser/pub").ConfigureAwait(false);
		result.Dump(TestContext);
	}
	[TestMethod]
	public async Task wifi_ap() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("wifi/ap").ConfigureAwait(false);
		result.Dump(TestContext);
	}
	


 
	[TestMethod]
	public async Task taskcount() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("taskcount").ConfigureAwait(false);
		result.Dump(TestContext);
	}
}
