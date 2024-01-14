// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using Microsoft.Extensions.Logging;

namespace FreeboxOs;

[TestClass]
public class ApiLanTests {
	
	 
	public TestContext TestContext { get; set; } = null!;




	[TestMethod]
	public async Task GetLanConfiguration() {
		using var api    = Settings.GetApi(TestContext);
		var       result = await api.GetLanConfiguration();
		result.Dump(TestContext);
	}
	[DataTestMethod]
	[DataRow("pub")]
	[DataRow("wifiguest")]
	public async Task LanBrowserHostAsync(string @interface) {
		using var api  =Settings.GetApi(TestContext,logLevel:LogLevel.Information);
		var result= await api.LanBrowserHostAsync(@interface);

		result.Dump(TestContext);
	}
	[DataTestMethod]
	[DataRow("pub")]
	[DataRow("wifiguest")]
	public async Task LanBrowserHostAsync_Enumerate_host_type(string @interface) {
		using var api  =Settings.GetApi(TestContext,logLevel:LogLevel.Information);
		var result= await api.LanBrowserHostAsync(@interface);
		if (result is null) return;
		 
		foreach( var item in result.Select(x => x.host_type).Distinct().OrderBy(x=>x)) {
			TestContext.WriteLine($"{item}");
		} 

	}
	[DataTestMethod]
	[DataRow("pub")]
	[DataRow("wifiguest")]
	public async Task LanBrowserHostAsync_Enumerate_LanHostL2IdentType(string @interface) {
		using var api  =Settings.GetApi(TestContext,logLevel:LogLevel.Information);
		var result= await api.LanBrowserHostAsync(@interface);
		if (result is null) return;
	
		foreach( var item in result.Select(x => x.l2ident?.type).Distinct().OrderBy(x=>x)) {
	 		TestContext.WriteLine($"{item}");
		}
	}

	[DataTestMethod]
	[DataRow("pub")]
	[DataRow("wifiguest")]
	public async Task LanBrowserHostAsync_AdditionalProperties(string @interface) {
		using var api  =Settings.GetApi(TestContext,logLevel:LogLevel.Information);
		var result= await api.LanBrowserHostAsync(@interface);
		if(result is null) return;
		foreach (var item in result) {
			item.EnsureAllDataDeserialized();
		}
		 
	}

	 
}
