// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public sealed class  LanHostName:JsonModel {
	/// <summary>
	/// Host name
	/// </summary>
	public string name { get; init; }
	/// <summary>
	/// source of the name
	/// </summary>
	public string source  { get; init; }

}
