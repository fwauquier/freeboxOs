// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using FreeboxOs.login;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;

[TestClass]
public class ApiLoginTests {

	[TestMethod]
	public void Credentials() {
		TestContext.WriteLine($"uri: {Settings.uri}");
		TestContext.WriteLine($"password: {Settings.password}");
		TestContext.WriteLine($"app_id: {Settings.app_id}");
		TestContext.WriteLine($"app_track_id: {Settings.app_track_id}");
		TestContext.WriteLine($"app_token: {Settings.app_token}");
	}

	public TestContext TestContext { get; set; } = default!;

	[TestMethod]
	public async Task LoginV3Dummy() {
		await Assert.ThrowsExceptionAsync<System.Net.Http.HttpRequestException>(async () =>
			await V3LoggingAsync("pas-changer-assiette-pour-fromage")
		);

	}

	private async Task V3LoggingAsync(string password) {
		using var api =  new Api(Settings.uri, password);
		api.Logger = Settings.GetLogger(TestContext, api.GetType().FullName,LogLevel.Trace);
		var loginResult = await api.Login();
		Assert.IsNotNull(loginResult);
		TestContext.WriteLine($"PasswordSalt: {loginResult.PasswordSalt}");

		Assert.IsNotNull(loginResult);
	}

	[TestMethod]
	public async Task LoginV3Correct() {
		await V3LoggingAsync(Settings.password);
	}

	[TestMethod]
	public async Task LoginV4GetAppToken() {
		using var api = Settings.GetApi(TestContext,LogLevel.Information);

		var authorize = new TokenRequest {
			app_id = api.app_id,
			app_name = api.app_name,
			app_version = api.app_version,
			device_name = api.device_name
		};
using 		var httpContent = Api.CreateContent(authorize);
		var result      =await api.PostAsync<TokenResponse>("login/authorize",httpContent) ;
		Assert.IsNotNull(result);
		TestContext.WriteLine($"track_id: {result.track_id}");
		TestContext.WriteLine($"app_token: {result.app_token}");


	}
	[TestMethod]
	public async Task LoginV4GetAuthorizationStatus() {
		using var api = Settings.GetApi(TestContext,LogLevel.Trace);
		//var progress=await api.GetAsync<Api.TrackAuthorizationProgress>($"/api/v4/login/authorize/{13}") ;
		var progress=await api.GetAsync<LoginInfo>($"login/authorize/{Settings.app_track_id}") ;
		Assert.IsNotNull(progress);
		TestContext.WriteLine($"status: {progress.status}");
		TestContext.WriteLine($"Challenge: {progress.Challenge}");
		progress.EnsureAuthorized();
	}




}
