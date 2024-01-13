// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.Models;

public class Download {
	[JsonPropertyName("rx_bytes")] public double RxBytes { get; set; }

	[JsonPropertyName("tx_bytes")] public double TxBytes { get; set; }

	[JsonPropertyName("download_dir")] public string DownloadDir { get; set; }

	[JsonPropertyName("archive_password")] public string ArchivePassword { get; set; }

	[JsonPropertyName("eta")] public int Eta { get; set; }

	[JsonPropertyName("status")] public string Status { get; set; }

	[JsonPropertyName("io_priority")] public string IoPriority { get; set; }

	[JsonPropertyName("type")] public string Type { get; set; }

	[JsonPropertyName("queue_pos")] public int QueuePosition { get; set; }

	[JsonPropertyName("id")] public int Id { get; set; }

	[JsonPropertyName("created_ts")] public int CreatedTs { get; set; }

	[JsonPropertyName("stop_ratio")] public int StopRatio { get; set; }

	[JsonPropertyName("tx_rate")] public int TxRate { get; set; }

	[JsonPropertyName("name")] public string Name { get; set; }

	[JsonPropertyName("tx_pct")] public int TxPct { get; set; }

	[JsonPropertyName("rx_pct")] public int RxPct { get; set; }

	[JsonPropertyName("rx_rate")] public int RxRate { get; set; }

	[JsonPropertyName("error")] public string Error { get; set; }

	[JsonPropertyName("size")] public object Size { get; set; }
}
