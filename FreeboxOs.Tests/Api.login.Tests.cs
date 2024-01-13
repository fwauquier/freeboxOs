// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

	public TestContext TestContext { get; set; }
	[TestMethod]
	public async Task LoginV3Dummy() {
		await Assert.ThrowsExceptionAsync<System.Net.Http.HttpRequestException>(async () =>
			await V3LoggingAsync("pas-changer-assiette-pour-fromage").ConfigureAwait(false)
		);

	}

	private async Task V3LoggingAsync(string password) {
		using var api =  new Api(Settings.uri, password);
		api.Logger = Settings.GetLogger(TestContext, api.GetType().FullName,LogLevel.Trace);
		var loginResult = await api.Login();
		TestContext.WriteLine($"PasswordSalt: {loginResult.PasswordSalt}");

		Assert.IsNotNull(loginResult);
	}

	[TestMethod]
	public async Task LoginV3Correct() {
		await V3LoggingAsync(Settings.password).ConfigureAwait(false);
	}

	[TestMethod]
	public async Task LoginV4GetAppToken() {
		using var api = Settings.GetApi(TestContext, false,LogLevel.Information);

		var authorize = new Api.TokenRequest {
			app_id = api.app_id,
			app_name = api.app_name,
			app_version = api.app_version,
			device_name = api.device_name
		};
		var result=await api.PostAsync<Api.TokenResponse>("login/authorize",api.CreateContent(authorize)) .ConfigureAwait(false);
		TestContext.WriteLine($"track_id: {result.track_id}");
		TestContext.WriteLine($"app_token: {result.app_token}");


	}
	[TestMethod]
	public async Task LoginV4GetAuthorizationStatus() {
		using var api = Settings.GetApi(TestContext, false,LogLevel.Trace);
		//var progress=await api.GetAsync<Api.TrackAuthorizationProgress>($"/api/v4/login/authorize/{13}") .ConfigureAwait(false);
		var progress=await api.GetAsync<Api.LoginInfo>($"login/authorize/{Settings.app_track_id}") .ConfigureAwait(false);
		TestContext.WriteLine($"status: {progress.status}");
		TestContext.WriteLine($"Challenge: {progress.Challenge}");
		progress.EnsureAuthorized();
	}




}
