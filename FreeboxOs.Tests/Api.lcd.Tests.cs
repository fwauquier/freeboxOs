// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >
 

namespace FreeboxOs;

[TestClass]
public class ApiLcdTests {

	public TestContext TestContext { get; set; } = null!;


	[TestMethod]
	public async Task LcdConfig() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.LcdConfig();
		result.Dump(TestContext);
	}

 

}
