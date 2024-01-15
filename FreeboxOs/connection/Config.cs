// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.connection;

public sealed class Config : JsonModel {
	public required bool allow_token_request { get; set; }
	public required bool adblock { get; set; }
	public required bool wol { get; set; }
	public required string sip_alg { get; set; }
	public required bool disable_guest { get; set; }
	public required int remote_access_min_port { get; set; }
	public required string api_domain { get; set; }
	public required bool remote_access { get; set; }
	public required bool is_secure_pass { get; set; }
	public required int https_port { get; set; }
	public required bool api_remote_access { get; set; }
	public required bool https_available { get; set; }
	public required string remote_access_ip { get; set; }
	public required int remote_access_port { get; set; }
	public required bool ping { get; set; }
	public required int remote_access_max_port { get; set; }
	public required bool adblock_not_set { get; set; }
}
