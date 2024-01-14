// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.parental;

/// <summary>
/// Parental filter configuration allow you to set the default filter_state to apply to hosts without rules on your network
/// </summary>
public sealed class Config : JsonModel {
	/// <summary>see available filter_state</summary>
	public required FilterState default_filter_mode { get; set; }

	 


}

public sealed class ParentalFilter : JsonModel {
	/// <summary>filter id</summary>
	public required int id { get; init; }
	 
}
