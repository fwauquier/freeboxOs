// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs;

// https: //dev.freebox.fr/sdk/os/lan/#lan-browser
public sealed partial class Api {
	/// <summary>
	/// Getting the list of browsable LAN interfaces
	/// </summary>
	/// <returns></returns>
	public async Task<LanBrowserInterface[]?> LanBrowserInterfacesAsync() {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LanBrowserInterface[]>("lan/browser/interfaces").ConfigureAwait(false);
	}

	/// <summary>
	/// Returns the list of LanHost on this interface
	/// </summary>
	/// <returns></returns>
	public async Task<LanHost[]?> LanBrowserHostAsync(string @interface) {
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LanHost[]>("lan/browser/"+@interface).ConfigureAwait(false);
	}

    /// <summary>
    /// Get the current Lan configuration
    /// </summary>
    public async Task<LanConfig?> GetLanConfiguration()
	{
		await EnsureLoginAsync().ConfigureAwait(false);
		return await GetAsync<LanConfig>("lan/config").ConfigureAwait(false);
	}

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum lanMode {
        /// <summary>
        /// The Freebox acts as a network router
        /// </summary>
		router,
        /// <summary>
        /// The Freebox acts as a network bridge
        /// </summary>
        bridge
    }

	public sealed class LanConfig : JsonModel {
		/// <summary> Freebox Server IPv4 address </summary>
		public required string ip { get; init; }

        /// <summary> Freebox Server name </summary>
        public required string name { get; init; }
		/// <summary> Freebox Server DNS name </summary>
		public required string name_dns { get; init; }

        /// <summary> Freebox Server mDNS name </summary>
        public required string name_mdns { get; init; }
        /// <summary>  Freebox Server netbios name</summary>
        public required string name_netbios { get; init; }
        /// <summary> LAN mode  </summary>
        /// <remarks>In bridge mode, most of Freebox services are disabled. It is recommended to use the router mode, and third party apps should not change this setting</remarks>
        public lanMode mode { get; init; }
	 
	 


    }
    }
