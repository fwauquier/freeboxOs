// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs.version;

public sealed class ApiVersion:JsonModel {
    /// <summary>The current API version on the Freebox</summary>
    public required string api_version { get; init; }

	/// <summary> “FreeboxServer1,1” for the Freebox Server revision 1,1</summary>
	public string? device_type { get; init; }

	/// <summary>The API root path on the HTTP server </summary>
	public required string api_base_url { get; init; }

	/// <summary>The device unique id </summary>
	public string? uid { get; init; }

	/// <summary>The domain to use in place of hardcoded Freebox ip </summary>
	public string? api_domain { get; init; }

	/// <summary> Tells if https has been configured on the Freebox</summary>
	public bool https_available { get; init; }

	/// <summary> 	Port to use for remote https access to the Freebox Api</summary>
	public int https_port { get; init; }

	/// <summary> "Freebox v7 (r1)"</summary>
	public string? box_model_name { get; init; }

	/// <summary> "Freebox Server"</summary>
	public string? device_name { get; init; }

	/// <summary> 	"fbxgw7-r1/full" </summary>
	public string? box_model { get; init; }


}
