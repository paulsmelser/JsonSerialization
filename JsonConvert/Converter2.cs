using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonConverterSample
{

    public class InteractionJsonConvert
    {

        public static Interaction DeseriealizeInteraction(string interactionString)
        {

            return JsonConvert.DeserializeObject<Interaction>(interactionString,
                new TriggerConverter(), new ObjectConverter());

        }
//
//
//        protected abstract class JsonCreationConverter<T> : JsonConverter
//        {
//
//            protected abstract Type GetType(Type objectType, JObject jObject);
//
//
//            public override bool CanConvert(Type objectType)
//            {
//
//                return typeof(T).IsAssignableFrom(objectType);
//
//            }
//
//
//            public override object ReadJson(JsonReader reader, Type objectType,
//
//                object existingValue, JsonSerializer serializer)
//            {
//
//                var jObject = JObject.Load(reader);
//
//
//                var target = GetType(objectType, jObject);
//
//
//                serializer.Populate(jObject.CreateReader(), target);
//
//
//                return target;
//
//            }
//
//
//            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
//            {
//
//                throw new NotImplementedException();
//
//            }
//
//        }
//
//
//        protected class TriggerConvert : JsonCreationConverter<ITrigger>
//        {
//
//            protected override Type GetType(Type objectType, JObject jObject)
//            {
//
//                var type = (string)jObject.Property("TriggerType");
//
//                switch (type)
//                {
//
//                    case "Buy":
//
//                        return typeof(Buy);
//
//                }
//
//
//                throw new ApplicationException(String.Format(
//
//                    "The given trigger type {0} is not supported!", type));
//
//            }
//
//        }
//
//
//        protected class ObjectConvert : JsonCreationConverter<IObject>
//        {
//
//            protected override Type GetType(Type objectType, JObject jObject)
//            {
//
//                var type = (string)jObject.Property("ObjectType");
//
//                switch (type)
//                {
//
//                    case "Product":
//
//                        return typeof(Product);
//
//                }
//
//
//                throw new ApplicationException(String.Format(
//
//                    "The given object type {0} is not supported!", type));
//
//            }
//
//        }




    }

    public class TriggerConverter : JsonCreationConverter<ITrigger>
    {
        protected override ITrigger Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("Type");
            switch (type)
                {
                    case "Buy":
                        return new Buy();
                }

                throw new ApplicationException(String.Format(
                    "The given trigger type {0} is not supported!", type));
        }
    }

    public class ObjectConverter : JsonCreationConverter<IObject>
    {
        protected override IObject Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("Type");
            switch (type)
            {
                case "Product":
                    return new Product();
            }

            throw new ApplicationException(String.Format(
                "The given object type {0} is not supported!", type));
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

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}