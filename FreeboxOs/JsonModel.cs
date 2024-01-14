// <copyright company = "Frederic Wauquier">
//    Copyright (c) Frederic Wauquier All rights reserved.
//    <author >Frederic Wauquier</author>
// </copyright >

namespace FreeboxOs;

public   class JsonModel {

	/// <summary>
	///     Additional properties
	/// </summary>
	[JsonExtensionData]
	// ReSharper disable once CollectionNeverUpdated.Global
	public Dictionary<string, object>? AdditionalProperties { get; init; }

#if DEBUG
	public static readonly JsonSerializerOptions jsonOptionIndented = new JsonSerializerOptions
	                                                                  {
		                                                                  WriteIndented = true,
		                                                                  IgnoreReadOnlyFields = true,
		                                                                  IgnoreReadOnlyProperties = true,
		                                                                  DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
	                                                                  };
	public static string Serialize(  object? obj)
	{
		return JsonSerializer.Serialize(obj, jsonOptionIndented);
	}
	public static string Reformat(string json) {
		var utf8Json = JsonSerializer.Deserialize<object>(json);
		return JsonSerializer.Serialize(utf8Json, jsonOptionIndented);
	}
    public void EnsureAllDataDeserialized() {
		var model = this;
        if(model.AdditionalProperties is null) return;
		var type  = model.GetType();
		if (model.AdditionalProperties.Count > 0) {
			throw new ApiException($"Some properties not deserialized for type {type.FullName}.{Environment.NewLine}{Serialize(model.AdditionalProperties)}");
		 
		}
		foreach (var property in type.GetProperties())
		{

			var value = property.GetValue(model);
			if (value is null) continue;
			if (value is JsonModel jsonModel)
			{
				jsonModel.EnsureAllDataDeserialized();
			}
			else if (value is IEnumerable<JsonModel> jsonModels)
			{
				foreach (var jsonModel2 in jsonModels)
				{
					jsonModel2.EnsureAllDataDeserialized();
				}
			}



		}
	}
#endif
}
