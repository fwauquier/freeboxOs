// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs;

public sealed class TokenResponse : JsonModel
{
	/// <summary> </summary>
	public required string app_token { get; init; }

	/// <summary> </summary>
	public required  int track_id { get; init; }


}
