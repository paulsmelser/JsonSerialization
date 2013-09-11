using System;
using Newtonsoft.Json;

namespace JsonConverterSample
{
    public class Converter
    {
        public static Interaction Deserialize(string stringRepresentation)
        {
            return JsonConvert.DeserializeObject<Interaction>(stringRepresentation,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Objects});
        }

        public static string Serialize(Interaction interaction)
        {
            return JsonConvert.SerializeObject(interaction,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto});
        }
    }

    public class Interaction
    {
        public Guid Id { get; set; }
        //[JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public ITrigger Trigger { get; set; }
        //[JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public IObject Object { get; set; }
        public Person Person { get; set; }
    }

    public interface ITrigger
    {
        string Name { get; set; }
    }

    public interface IObject
    {
        string Hello { get; set; }
    }

    public class Buy : ITrigger
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Bye { get; set; }
    }

    public class Product : IObject
    {
        public string Type { get; set; } 
        public string Hello { get; set; }
        public double Price { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
