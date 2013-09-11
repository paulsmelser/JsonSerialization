using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonConverterSample
{

    public class InteractionJsonConvert
    {

        public static JsonConverterContracts.Interaction DeseriealizeInteraction(string interactionString)
        {

            return JsonConvert.DeserializeObject<JsonConverterContracts.Interaction>(interactionString,
                new TriggerConverter(), new ObjectConverter());

        }

    }

    public class TriggerConverter : JsonCreationConverter<JsonConverterContracts.ITrigger>
    {
        protected override JsonConverterContracts.ITrigger Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("Type");
            switch (type)
                {
                    case "Buy":
                        return new JsonConverterContracts.Buy();
                }

                throw new ApplicationException(String.Format(
                    "The given trigger type {0} is not supported!", type));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var trigger = value as JsonConverterContracts.Buy;
            writer.WriteStartObject();
            writer.WritePropertyName("Type");
            serializer.Serialize(writer, trigger.Type);
            writer.WritePropertyName("Name");
            serializer.Serialize(writer, trigger.Name);
            writer.WritePropertyName("Bye");
            serializer.Serialize(writer, ((JsonConverterContracts.Buy)trigger).Bye);
            writer.WriteEndObject();
        }
    }

    public class ObjectConverter : JsonCreationConverter<JsonConverterContracts.IObject>
    {
        protected override JsonConverterContracts.IObject Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("Type");
            switch (type)
            {
                case "Product":
                    return new JsonConverterContracts.Product();
            }

            throw new ApplicationException(String.Format(
                "The given object type {0} is not supported!", type));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = value as JsonConverterContracts.Product;

            writer.WriteStartObject();
            writer.WritePropertyName("Type");
            serializer.Serialize(writer, obj.Type);
            writer.WritePropertyName("Hello");
            serializer.Serialize(writer, obj.Hello);
            writer.WritePropertyName("Price");
            serializer.Serialize(writer, obj.Price);
            writer.WriteEndObject();
        }
    }

    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">contents of JSON object that will be deserialized</param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}