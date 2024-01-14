// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

 

namespace FreeboxOs;

[TestClass]
public class ApiWifiTests {

	public TestContext TestContext { get; set; } = null!;


	[TestMethod]
	public async Task WifiBss() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.WifiBss();
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task WifiConfig() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.WifiConfig();
		result.Dump(TestContext);
	}




}
