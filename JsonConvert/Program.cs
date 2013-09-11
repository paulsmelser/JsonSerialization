using System;
using Newtonsoft.Json;

namespace JsonConverterSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var interaction = new Interaction
            {
                Id = new Guid(),
                Object = new Product
                {
                    Type = "Product",
                    Hello = "Hi",
                    Price = 99.99
                },
                Person = new Person
                {
                    FirstName = "Paul",
                    LastName = "Smelser"
                },
                Trigger = new Buy
                {
                    Type = "Buy",
                    Bye = "Goodbye",
                    Name = "TheName"
                }
            };

//            var serialized = Converter.Serialize(interaction);
//            var deserialized = Converter.Deserialize(serialized);
//
//            var price = ((Product) deserialized.Object).Price;

            var serializedWithContract = JsonConvert.SerializeObject(interaction);
           // var deserializeWithContract = JsonConvert.DeserializeObject<Interaction>(serializedWithContract);

           // var priceContract = ((Product)deserializeWithContract.Object).Price;

            var deserializedConverter = InteractionJsonConvert.DeseriealizeInteraction(serializedWithContract);
        }
    }
}
