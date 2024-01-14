// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public class AddDownloadResult {
	public bool Success { get; init; }
    public required List<int> TaskId { get; init; }
}
