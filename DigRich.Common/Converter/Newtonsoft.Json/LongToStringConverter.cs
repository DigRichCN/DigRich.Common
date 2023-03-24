﻿using Newtonsoft.Json.Linq;
using System;

namespace Newtonsoft.Json {
    /// <summary>
    /// 将ID转为string类型
    /// </summary>
    public class LongToStringConverter : JsonConverter {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            JToken jt = JValue.ReadFrom(reader);

            return jt.Values();
        }

        public override bool CanConvert(Type objectType) {
            return typeof(System.Int64).Equals(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
