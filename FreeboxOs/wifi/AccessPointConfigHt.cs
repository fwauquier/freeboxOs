// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class AccessPointConfigHt : JsonModel {
	public bool? greenfield { get; set; }
	public bool? shortgi20 { get; set; }
	public bool? vht_rx_ldpc { get; set; }
	public bool? ldpc { get; set; }
	public string? vht_rx_stbc { get; set; }
	public bool? vht_shortgi80 { get; set; }
	public bool? vht_mu_beamformer { get; set; }
	public string? vht_sounding_dimensions { get; set; }
	public bool? ht_enabled { get; set; }
	public string? rx_stbc { get; set; }
	public bool? dsss_cck_40 { get; set; }
	public bool? tx_stbc { get; set; }
	public bool? ac_enabled { get; set; }
	public string? smps { get; set; }
	public bool? vht_shortgi160 { get; set; }
	public string? vht_beamformee_sts { get; set; }
	public bool? vht_tx_stbc { get; set; }
	public bool? vht_su_beamformee { get; set; }
	public bool? vht_su_beamformer { get; set; }
	public bool? delayed_ba { get; set; }
	public bool? vht_tx_antenna_consistency { get; set; }
	public bool? max_amsdu_7935 { get; set; }
	public int? vht_max_ampdu_len_exp { get; set; } // 0,
	public string? vht_max_mpdu_len { get; set; }   // public bool? defaultpublic bool? ,
	public bool? psmp { get; set; }
	public bool? shortgi40 { get; set; }
	public bool? vht_rx_antenna_consistency { get; set; }
	public bool? lsig_txop_prot { get; set; }
}
