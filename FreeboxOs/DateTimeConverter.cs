// <copyright>
// Copyright (c) Frederic Wauquier rights reserved.
// <author > Frederic Wauquier</author >
// </copyright >

namespace FreeboxOs;

public class NullableDateTimeConverter : JsonConverter<DateTime?> {
	public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		try {
			var int64 = reader.GetInt64();
			return DateTime.UnixEpoch.AddSeconds(int64).ToLocalTime();
		} catch (Exception) {
			return null;
		}
	}

	public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options) {
		if (value is null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteNumberValue((value.Value - DateTime.UnixEpoch).TotalSeconds);
	}
}
public class DateTimeConverter : JsonConverter<DateTime> {
	public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		var int64 = reader.GetInt64();
		return DateTime.UnixEpoch.AddSeconds(int64).ToLocalTime();
	}

	public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) {
 	writer.WriteNumberValue((value - DateTime.UnixEpoch).TotalSeconds);
	}
}

public class TimeSpanConverter : JsonConverter<TimeSpan> {
	public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		var int64 = reader.GetInt64();
		return TimeSpan.FromSeconds(int64);
	}

	public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) {
		writer.WriteNumberValue((long) value.TotalSeconds);
	}
}
