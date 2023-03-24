using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Text.Json {
    
    public class LongToStringConverter : JsonConverter<long> {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            return long.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString());
        }
    }
}
