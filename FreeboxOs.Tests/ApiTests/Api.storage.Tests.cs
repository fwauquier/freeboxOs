// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.ApiTests;

[TestClass]
public class ApiStorageTests {

	public TestContext TestContext { get; set; } = null!;


 
	[TestMethod]
	public async Task StorageDisk() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.StorageDisk();
		Assert.IsNotNull(result);
	 
		result.Dump(TestContext);
	}

	//
	// [TestMethod]
	// public async Task WifiAp() {
	// 	using var api    = Settings.GetApi(TestContext);
	// 	var       result = await api.WifiAp();
	//
	// 	Assert.IsNotNull(result);
	// 	foreach (var item in result) {
	// 		TestContext.WriteLine($"id:{item.id} name:{item.name,-5} band:{item.config.band,-5} channel_width:{item.status.channel_width,-3} primary_channel:{item.status.primary_channel,-3} secondary_channel:{item.status.secondary_channel,-3} {item.status.state}");
	// 	}
	// 	result.Dump(TestContext);
	// }



}
