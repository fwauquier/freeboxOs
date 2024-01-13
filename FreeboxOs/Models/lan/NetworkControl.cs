// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public sealed class NetworkControl : JsonModel {
		public NetworkControlMode current_mode  { get; init; }
		public int profile_id  { get; init; }
		public string name  { get; init; }
	}
