// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public class AddDownload {
	public required Uri DownloadUrl { get; init; }
    public required List<Uri> DownloadUrls { get; init; }
    public required string DownloadDir { get; init; }
	public bool Recursive { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string ArchivePassword { get; init; }
    public required string Cookies { get; init; }
}
