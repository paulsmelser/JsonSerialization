using Newtonsoft.Json;

namespace JsonConverterSample
{
    public class Converter
    {
        public static JsonContracts.Interaction Deserialize(string stringRepresentation)
        {
            return JsonConvert.DeserializeObject<JsonContracts.Interaction>(stringRepresentation,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Objects});
        }

        public static string Serialize(JsonContracts.Interaction interaction)
        {
            return JsonConvert.SerializeObject(interaction,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto});
        }
    }
}
