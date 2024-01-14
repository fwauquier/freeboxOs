// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.ApiTests;

[TestClass]
public class ApiTests {
	public TestContext TestContext { get; set; } = default!;

	[DataTestMethod]
	[DataRow("http://mafreebox.freebox.fr")]
	[DataRow("http://192.168.0.254")]
	public async Task GetVersionAsync(string uri) {
		var server = new Api(new Uri(uri), "");
		server.Logger = Settings.GetLogger(TestContext, server.GetType().FullName);
		using var api    = server;
		var       result = await api.GetVersionAsync();
		result.Dump(TestContext);
	}
}
