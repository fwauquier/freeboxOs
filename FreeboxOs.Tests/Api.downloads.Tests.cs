// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreeboxOs;

[TestClass]
public class ApiDownloadsTests {

	public TestContext TestContext { get; set; }

	// [TestMethod]
	// public async Task AddDownload()
	// {
	//     var api = Settings.GetApi(TestContext);
	//     var loginResult = await api.LoginAsync();
	//     Assert.IsTrue(loginResult);
	//
	//     var result =
	//         await api.AddDownload(
	//             new Uri("http://ftp.free.org/mirrors/videolan/vlc/2.2.1/win32/vlc-2.2.1-win32.exe"));
	//     Assert.IsTrue(result.Success);
	//     Assert.IsTrue(result.TaskId.Count == 1);
	//     Assert.IsTrue(result.TaskId.Single() > 0);
	// }

	// [TestMethod]
	// public async Task AddDownloadPasswordProtected()
	// {
	//     var api = Settings.GetApi(TestContext);
	//     var loginResult = await api.LoginAsync();
	//     Assert.IsTrue(loginResult);
	//
	//     var result = await api.AddDownload(new Uri("https://httpbin.org/basic-auth/user/passwd"), "user", "passwd");
	//     Assert.IsTrue(result.Success);
	//     Assert.IsTrue(result.TaskId.Count == 1);
	//     Assert.IsTrue(result.TaskId.Single() > 0);
	// }

}
