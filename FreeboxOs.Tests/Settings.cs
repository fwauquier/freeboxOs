// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FreeboxOs;

public class Settings {
	static Settings() {
		var builder = new ConfigurationBuilder().AddUserSecrets(typeof(Settings).Assembly, false, false);
		var configuration = builder.Build();
		uri = new Uri(configuration["uri"]!);
		password = configuration["password"]!;
		app_id = configuration["app_id"]!;
		app_token = configuration["app_token"]!;
		app_version = configuration["app_version"]!;
		if(int.TryParse(configuration["app_track_id"], out var i)) app_track_id = i;
	}


	public static string password { get; }
	public static string app_id { get; }
	public static string app_token { get; }
	public static int app_track_id { get; }
	public static Uri uri { get; }
	public static string app_version { get; }

	public static ILogger GetLogger(TestContext context, string? name = null, LogLevel logLevel = LogLevel.Information) {
		return new TestContextLogger(context, name ?? typeof(Settings).FullName!, logLevel);
	}

	public static Api GetApi(TestContext context, LogLevel logLevel = LogLevel.Information) {
		var server = new Api(uri, password);
		server.Logger = GetLogger(context, server.GetType().FullName, logLevel);
		return server;
	}

	/// <summary>
	///     A logger that writes messages in the debug output window only when a debugger is attached.
	/// </summary>
	internal sealed class TestContextLogger : ILogger {
		private readonly string _name;
		private readonly TestContext m_TestContext;

		/// <summary>
		///     Initializes a new instance of the <see cref="TestContextLogger" /> class.
		/// </summary>
		/// <param name="testContext"></param>
		/// <param name="name">The name of the logger.</param>
		/// <param name="logLevel"></param>
		public TestContextLogger(TestContext testContext, string name, LogLevel logLevel = LogLevel.Information) {
			LogLevel = logLevel;
			m_TestContext = testContext;
			_name = name;
		}

		public LogLevel LogLevel { get; }

		/// <inheritdoc />
		public IDisposable BeginScope<TState>(TState state)
			where TState : notnull {
			return NullScope.Singleton;
		}

		/// <inheritdoc />
		public bool IsEnabled(LogLevel logLevel) {
			// Everything is enabled unless the debugger is not attached
			return logLevel >= LogLevel && logLevel != LogLevel.None;
		}

		/// <inheritdoc />
		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) {
			if (!IsEnabled(logLevel)) return;
			ArgumentNullException.ThrowIfNull(formatter);

			var message = formatter(state, exception);

			if (string.IsNullOrEmpty(message)) return;

			message = $"{logLevel}: {message}";

			if (exception != null) message += Environment.NewLine + Environment.NewLine + exception;

			//m_TestContext.WriteLine("[" + _name + "]" + message);
			m_TestContext.WriteLine(message);
		}

		internal sealed class NullScope : IDisposable {
			private NullScope() {
			}

			// ReSharper disable once ArrangeObjectCreationWhenTypeEvident
			public static NullScope Singleton { get; } = new();

			/// <inheritdoc />
			public void Dispose() {
			}
		}
	}
}
