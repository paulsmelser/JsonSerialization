using System;
using Newtonsoft.Json;

namespace JsonConverterSample
{
    public class JsonConverterContracts
    {
        public class Interaction
        {
            public ITrigger Trigger { get; set; }
            public IObject Object { get; set; }
            public Person Person { get; set; }

            public override string ToString()
            {
                return string.Format("Trigger: {0} | Object : {1} | Person : {2}", Trigger, Object, Person);
            }
        }
        [JsonConverter(typeof(TriggerConverter))]
        public interface ITrigger
        {
            string Type { get; set; }
            string Name { get; set; }
        }
        [JsonConverter(typeof(ObjectConverter))]
        public interface IObject
        {
            string Type { get; set; }
            string Hello { get; set; }
        }

        public class Buy : ITrigger
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Bye { get; set; }
            public override string ToString()
            {
                return string.Format("Type = {0}, Name={1}, Bye={2}", Type, Name, Bye);
            }
        }

        public class Product : IObject
        {
            public string Type { get; set; }
            public string Hello { get; set; }
            public double Price { get; set; }

            public override string ToString()
            {
                return string.Format("Type={0}, Hello={1}, Price={2}", Type, Hello, Price);
            }
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
