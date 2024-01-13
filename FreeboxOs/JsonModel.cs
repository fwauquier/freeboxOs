// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs;

public   class JsonModel {

	/// <summary>
	///     Additional properties
	/// </summary>
	[JsonExtensionData]
	// ReSharper disable once CollectionNeverUpdated.Global
	public Dictionary<string, object> AdditionalProperties { get; init; } = [];
#if DEBUG
	public Dictionary<string, object> ExcessiveProperties => AdditionalProperties;
#endif

}
