// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.lan;

public sealed class Layer2Identifier:JsonModel {
	/// <summary> Layer 2 id </summary>
	public required string id  { get; init; }
	/// <summary> Type of layer 2 address </summary>
	public required Layer2IdentifierType type { get; init; }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Layer2IdentifierType {
	/// <summary>mac_address</summary>
	mac_address,
}
