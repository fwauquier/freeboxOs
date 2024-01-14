// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs;

[TestClass]
public class Study {
	public TestContext TestContext { get; set; } = null!;


	[TestMethod]
	public async Task ParentalFilters() {
		using var api = Settings.GetApi(TestContext);
		await api.EnsureLoginAsync().ConfigureAwait(false);
		var result = await api.GetAsync<object>("network_control").ConfigureAwait(false);
		result.Dump(TestContext);
	}



}
