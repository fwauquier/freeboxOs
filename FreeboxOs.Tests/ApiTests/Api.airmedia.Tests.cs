// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.ApiTests;

[TestClass]
public class ApiAirmediaTests {

	
	public TestContext TestContext { get; set; } = null!;


	// [TestMethod]
	// public async Task ListAirmedia() {
	// 	var api = Settings.GetApi(TestContext);
	// 	var loginResult = await api.LoginAsync();
	// 	Assert.IsTrue(loginResult);
	//
	// 	var airmediaResults = await api.ListAirmediaReceivers();
	// 	Assert.IsTrue(airmediaResults.Any());
	// }
	//
	// [TestMethod]
	// public async Task ListDownloads() {
	// 	var api = Settings.GetApi(TestContext);
	// 	var loginResult = await api.LoginAsync();
	// 	Assert.IsTrue(loginResult);
	//
	// 	var downloads = await api.ListDownloads();
	// 	Assert.IsTrue(downloads.Any());
	// }

	// [TestMethod]
	// public async Task PlayMedia()
	// {
	//     var api = Settings.GetApi(TestContext);
	//     var loginResult = await api.LoginAsync();
	//     Assert.IsTrue(loginResult);
	//
	//     var airmediaResults = (await api.ListAirmediaReceivers()).ToList();
	//     Assert.IsTrue(airmediaResults.Any());
	//
	//     var freeboxPlayer = airmediaResults.First(r => r.Name.Contains("Player"));
	//     var request = new AirMediaReceiverRequest
	//     {
	//         Action = Action.Start,
	//         Media = "https://www.hq.nasa.gov/alsj/a11/a11v.1092418-0354.avi",
	//         MediaType = MediaType.Video
	//     };
	//     var startResult = await api.SendAirMediaReceiverRequest(freeboxPlayer.Name, request);
	//     Assert.IsTrue(startResult);
	// }
}
