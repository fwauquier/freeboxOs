// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.lan;

public sealed class BrowserInterface:JsonModel {
	public required string name { get; init; }
	public int host_count { get; init; }

}
