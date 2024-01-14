// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs.wifi;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BssEncryption { wpa2_psk_ccmp, wpa2_psk_tkip }
