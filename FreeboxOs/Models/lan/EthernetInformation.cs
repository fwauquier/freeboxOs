// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public sealed class EthernetInformation : JsonModel {
	public string duplex { get; init; } // ": "full",
	public string speed{ get; init; } // ": "1000",
	public long max_port_speed{ get; init; } // ": 1000000,
	public string link{ get; init; } // ": "up"
}
