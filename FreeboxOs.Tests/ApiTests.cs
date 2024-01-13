// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreeboxOs;

[TestClass]
public class ApiTests {

	public TestContext TestContext { get; set; }

	[TestMethod]
	public async Task GetVersionAsync() {
		using var api = Settings.GetApi(TestContext, false, LogLevel.Trace);
		var result = await api.GetVersionAsync().ConfigureAwait(false);
		result.Dump(TestContext);
	}

}
