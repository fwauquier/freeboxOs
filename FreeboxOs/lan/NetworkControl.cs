// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.lan;

public sealed class NetworkControl : JsonModel {
		public required NetworkControlMode current_mode  { get; init; }
		public required int profile_id  { get; init; }
		public required string name  { get; init; }
	}
