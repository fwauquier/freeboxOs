// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.lan;

public sealed class HostName : JsonModel {
	/// <summary>
	///     Host name
	/// </summary>
	public required string name { get; init; }

	/// <summary>
	///     source of the name
	/// </summary>
	public required HostNameSource source { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HostNameSource {
	upnp,
	dhcp,
	mdns,
	mdns_srv,
	netbios,
	wsd
}
