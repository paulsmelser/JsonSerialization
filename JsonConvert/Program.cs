using System;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace JsonConverterSample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var interaction = new JsonContracts.Interaction
            {
                Object = new JsonContracts.Product
                {
                    Type = "Product",
                    Hello = "Hi",
                    Price = 99.99
                },
                Person = new JsonContracts.Person
                {
                    FirstName = "Paul",
                    LastName = "Smelser"
                },
                Trigger = new JsonContracts.Buy
                {
                    Type = "Buy",
                    Bye = "Goodbye",
                    Name = "TheName"
                }
            };

            var serialized = JsonConvert.SerializeObject(interaction, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            Console.WriteLine("Serialized: {0}", serialized);
            var deserialized = JsonConvert.DeserializeObject<JsonContracts.Interaction>(serialized, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            Console.WriteLine("Deserialized to types: {0}\n", deserialized);
            //var serialized = Converter.Serialize(interaction);
            //var deserialized = Converter.Deserialize(serialized);

            //With JsonPropertyAttribute

            var interactionProperty = new JsonPropertyContract.Interaction
            {
                Object = new JsonPropertyContract.Product
                {
                    Type = "Product",
                    Hello = "Hi",
                    Price = 99.99
                },
                Person = new JsonPropertyContract.Person
                {
                    FirstName = "Paul",
                    LastName = "Smelser"
                },
                Trigger = new JsonPropertyContract.Buy
                {
                    Type = "Buy",
                    Bye = "Goodbye",
                    Name = "TheName"
                }
            };

            var serializedProperty = JsonConvert.SerializeObject(interactionProperty);
            Console.WriteLine("Serialized using JsonPropertyAttribute: {0}", serializedProperty);
            var deserializedProperty = JsonConvert.DeserializeObject<JsonPropertyContract.Interaction>(serializedProperty);
            Console.WriteLine("Deserialized using JsonPropertyAttribute: {0}\n", deserializedProperty.Trigger);

            //with JsonConverterAttribute
            var interactionConverter = new JsonConverterContracts.Interaction
            {
                Object = new JsonConverterContracts.Product
                {
                    Type = "Product",
                    Hello = "Hi",
                    Price = 99.99
                },
                Person = new JsonConverterContracts.Person
                {
                    FirstName = "Paul",
                    LastName = "Smelser"
                },
                Trigger = new JsonConverterContracts.Buy
                {
                    Type = "Buy",
                    Bye = "Goodbye",
                    Name = "TheName"
                }
            };

            var serializedConverter = JsonConvert.SerializeObject(interactionConverter);
            Console.WriteLine("Serialized using JsonConverterAttribute: {0}", serializedConverter);
            var deserializedConverter = JsonConvert.DeserializeObject<JsonConverterContracts.Interaction>(serializedConverter);
            Console.WriteLine("Deserialized using JsonConverterAttribute: {0}\n", deserializedConverter);

            Console.ReadKey();
//            var newDeserialized = "{\"Id\":\"00000000-0000-0000-0000-000000000000\",\"Trigger\":{\"$type\":\"JsonConverterSample.Buy, JsonConverterSample\",\"Type\":\"Buy\",\"Name\":\"TheName\",\"Bye\":\"Goodbye\"},\"Object\":{\"$type\":\"JsonConverterSample.Product, JsonConverterSample\",\"Type\":\"Product\",\"Hello\":\"Hi\",\"Price\":99.99},\"Person\":{\"FirstName\":\"Paul\",\"LastName\":\"Smelser\"}}";
////            var price = ((Product) deserialized.Object).Price;

//            var last = JsonConvert.DeserializeObject<JsonContracts.Interaction>(newDeserialized, new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Objects});
//            var serializedWithContract = JsonConvert.SerializeObject(interaction);
//           // var deserializeWithContract = JsonConvert.DeserializeObject<Interaction>(serializedWithContract);

//           // var priceContract = ((Product)deserializeWithContract.Object).Price;

//            //var deserializedConverter = InteractionJsonConvert.DeseriealizeInteraction(serializedWithContract);
        }
    }
}
