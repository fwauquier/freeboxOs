// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lan;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;

[TestClass]
public class Study {
	public TestContext TestContext { get; set; } = null!;
 



	[TestMethod]
	public async Task taskcount() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("taskcount").ConfigureAwait(false);
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task settings() {
		using var api = Settings.GetApi(TestContext, LogLevel.Trace);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("settings").ConfigureAwait(false);
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task connection_config() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("connection/config").ConfigureAwait(false);
		result.Dump(TestContext);
	}

	[TestMethod]
	public async Task upload() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("upload").ConfigureAwait(false);
		result.Dump(TestContext);
	}
}
