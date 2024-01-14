// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

using FreeboxOs.lan;

namespace FreeboxOs;

[TestClass]
public class ApiVersionTests {
	public TestContext TestContext { get; set; } = default!;

	[TestMethod]
	public async Task HostByProfile() {
		using var api    = Settings.GetApi(TestContext);
		var       hosts  =await api.LanBrowserHostAsync("pub");
		Assert.IsNotNull(hosts);
		var profiles = await api.GetProfiles();
		Assert.IsNotNull(profiles);

		var orphanHost=new List<LanHost>();

		foreach (var host in hosts) {
			var found = false;
			foreach (var profile in profiles) {
				if (profile.hosts.Any(i=>i.id==host.id)) {
					found = true;
					break;
				}
			}

			if (!found) {
				orphanHost.Add(host);
			}
		}
		TestContext.WriteLine($"*** Not assign to a profile ***************************************************************************************************************************");
		foreach (var host in orphanHost.OrderBy(i => i.primary_name)) {
			TestContext.WriteLine($"primary_name:{host.primary_name} active:{host.active} last_activity:{host.last_activity} first_activity:{host.first_activity}");
		}
		foreach (var profile in profiles.OrderBy(i=>i.profile_name)) {
			TestContext.WriteLine(string.Empty);
		
		TestContext.WriteLine($"*** {profile.profile_name} ***************************************************************************************************************************");
		foreach (var host in profile.hosts.OrderBy(i => i.primary_name)) {
			TestContext.WriteLine($"primary_name:{host.primary_name} active:{host.active} last_activity:{host.last_activity} first_activity:{host.first_activity}");
		}
}

		//var       server = new Api(new Uri(uri), "");
		//server.Logger = Settings.GetLogger(TestContext, server.GetType().FullName);
		//using var api    = server;
		//var       result = await api.GetVersionAsync();
		//result.Dump(TestContext);
	}
}
