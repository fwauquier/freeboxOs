// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

public sealed class ApConfigHe : JsonModel {
	public bool? enabled { get; set; }
	public bool? su_beamformee { get; set; }
	public bool? twt_responder { get; set; }
	public bool? su_beamformer { get; set; }
	public bool? twt_required { get; set; }
	public bool? mu_beamformer { get; set; }
}
