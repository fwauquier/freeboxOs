// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lan;

namespace FreeboxOs.ApiTests;

[TestClass]
public class Study {
	public TestContext TestContext { get; set; } = null!;


	[TestMethod]
	public async Task network_control() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<network_control.NetworkControl[]>("network_control").ConfigureAwait(false);
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
	public async Task taskcount() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("taskcount").ConfigureAwait(false);
		result.Dump(TestContext);
	}
}
