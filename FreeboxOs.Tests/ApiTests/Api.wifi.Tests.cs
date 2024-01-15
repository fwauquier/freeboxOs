// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.ApiTests;

[TestClass]
public class ApiWifiTests {
	public TestContext TestContext { get; set; } = null!;

	[TestMethod]
	public async Task WifiBss() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.WifiBss();
		Assert.IsNotNull(result);
		foreach (var item in result)
			TestContext.WriteLine($"id:{item.id} name:{item.config.ssid} band:{item.status.band} key:{item.config.key} encryption:{item.config.encryption} hide_ssid:{item.config.hide_ssid} state:{item.status.state}");
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task WifiConfig() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.WifiConfig();
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task WifiAccessPoint() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.WifiAccessPoint();

		Assert.IsNotNull(result);
		foreach (var item in result)
			TestContext.WriteLine($"id:{item.id} name:{item.name,-5} band:{item.config.band,-5} channel_width:{item.status.channel_width,-3} primary_channel:{item.status.primary_channel,-3} secondary_channel:{item.status.secondary_channel,-3} {item.status.state}");
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task WifiAccessPoint_0() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.WifiAccessPoint(0);

		Assert.IsNotNull(result);
		TestContext.WriteLine($"id:{result.id} name:{result.name,-5} band:{result.config.band,-5} channel_width:{result.status.channel_width,-3} primary_channel:{result.status.primary_channel,-3} secondary_channel:{result.status.secondary_channel,-3} {result.status.state}");

		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task WifiMacFilter() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.WifiMacFilter();

		Assert.IsNotNull(result);
		foreach (var item in result) TestContext.WriteLine($"id:{item.id} type:{item.type,-10} hostname:{item.hostname,-40} mac:{item.mac}");
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task wifi_ap_0_Station() {
		using var api = Settings.GetApi(TestContext);

		var aps = await api.WifiAccessPoint().ConfigureAwait(false);
		Assert.IsNotNull(aps);
		foreach (var ap in aps) {
			TestContext.WriteLine($"**** ap:{ap.id} {ap.name}");
			var result = await api.Stations(ap.id).ConfigureAwait(false);

			//		var result = await api.GetAsync<Host[]>("wifi/ap/1/stations").ConfigureAwait(false);
			result.Dump(TestContext);
		}
	}
}
