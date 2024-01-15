// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >



namespace FreeboxOs.ApiTests;

[TestClass]
public class ApiConnectionTests {

	public TestContext TestContext { get; set; } = null!;


	[TestMethod]
	public async Task ConnectionConfig() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.ConnectionConfig();
		result.Dump(TestContext);
	}
 

}
