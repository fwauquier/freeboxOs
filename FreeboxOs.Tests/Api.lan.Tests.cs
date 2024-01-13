// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreeboxOs;

[TestClass]
public class ApiLanTests {
	public TestContext TestContext { get; set; }


	[TestMethod]
	public async Task LanBrowserInterfacesAsync() {
		using var api =Settings.GetApi(TestContext);
		var result= await api.LanBrowserInterfacesAsync();
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
		TestContext.WriteLine("public enum hostType{");
		foreach( var item in result.Select(x => x.host_type).Distinct().OrderBy(x=>x)) {
			TestContext.WriteLine($"/// <summary>{item}</summary>");
			TestContext.WriteLine($"{item},");
		}
		TestContext.WriteLine(" }");

	}
	[DataTestMethod]
	[DataRow("pub")]
	[DataRow("wifiguest")]
	public async Task LanBrowserHostAsync_Enumerate_LanHostL2IdentType(string @interface) {
		using var api  =Settings.GetApi(TestContext,logLevel:LogLevel.Information);
		var result= await api.LanBrowserHostAsync(@interface);
		if (result is null) return;
		TestContext.WriteLine("public enum LanHostL2IdentType{");
		foreach( var item in result.Select(x => x.l2ident?.type).Distinct().OrderBy(x=>x)) {
			TestContext.WriteLine($"/// <summary>{item}</summary>");
			TestContext.WriteLine($"{item},");
		}
		TestContext.WriteLine(" }");
	}

	[DataTestMethod]
	[DataRow("pub")]
	[DataRow("wifiguest")]
	public async Task LanBrowserHostAsync_AdditionalProperties(string @interface) {
		using var api  =Settings.GetApi(TestContext,logLevel:LogLevel.Information);
		var result= await api.LanBrowserHostAsync(@interface);
		if (result is null) return;
		foreach(var item in result) {
			DumpAdditionalProperties(item );
			DumpAdditionalProperties(item.l2ident );
			DumpAdditionalProperties(item.access_point );
			DumpAdditionalProperties(item.access_point?.wifi_information );
			DumpAdditionalProperties(item.access_point?.ethernet_information );
			DumpAdditionalProperties(item.network_control );

			if (item.l3connectivities != null)
				foreach (var i2 in item.l3connectivities) {
					DumpAdditionalProperties(i2);
				}

			if (item.names != null)
				foreach (var i2 in item.names) {
					DumpAdditionalProperties(i2);
				}
		}
	}

	private void DumpAdditionalProperties(JsonModel? model ) {
		if (model is null) return;
		var type = model.GetType();
		if (model.AdditionalProperties.Count > 0) {
			TestContext.WriteLine($"*** Additional properties for {type.Name} ****");
			model.AdditionalProperties.Dump(TestContext);
		}
		foreach(var property in  type.GetProperties()) {
			var pp = property.PropertyType;
			#TODO
		}
	}
}
