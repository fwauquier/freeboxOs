// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >
 

namespace FreeboxOs;

[TestClass]
public class ApidhcpTests {

	public TestContext TestContext { get; set; } = null!;


	[TestMethod]
	public async Task DhcpConfig() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.DhcpConfig();
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task DhcpStaticLease() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.DhcpStaticLease();
		result.Dump(TestContext);
	}
	[TestMethod]
	public async Task DhcpDynamicLease() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.DhcpDynamicLease();
		//result.Dump(TestContext);
		Assert.IsNotNull(result);
		foreach (var item in result.OrderBy(i=>i.hostname)) {
			TestContext.WriteLine($"{item.hostname} - {item.assign_time:s} - {item.refresh_time:s} - {item.lease_remaining:g}");
		}
	}

}
