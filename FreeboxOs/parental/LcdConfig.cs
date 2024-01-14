// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.lcd;

public sealed class LcdConfig : JsonModel {
	/// <summary>the screen brightness (range from 0 to 100)</summary>
	public required int brightness { get; set; }

	/// <summary>is the screen orientation forced</summary>
	public required bool orientation_forced { get; set; }
	/// <summary> the screen orientation angle </summary>
	public required int orientation { get; set; }

 public required bool hide_wifi_key { get; set; }



}
