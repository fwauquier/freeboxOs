// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.ApiTests;

[TestClass]
public class ApiParentalTests {

	public TestContext TestContext { get; set; } = null!;


	[TestMethod]
	public async Task ParentalConfig() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.ParentalConfig();
		result.Dump(TestContext);
	}

	// [TestMethod]
	// public async Task ParentalFilters() {
	// 	using var api    = Settings.GetApi(TestContext);
	// 	var       result = await api.ParentalFilters();
	// 	result.Dump(TestContext);
	// }
}
