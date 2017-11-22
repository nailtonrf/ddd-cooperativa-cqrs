using Infraestructure.Core;
using Infraestructure.Core.Serializer;

namespace Infraestructure.SerializerProvider
{
    public class JsonProvider : ISerializer
    {
        public string Serialize(object @object)
        {
            Contract.ArgumentNullValidation(@object, nameof(@object));
            return Newtonsoft.Json.JsonConvert.SerializeObject(@object);
        }

        public T Deserialize<T>(string objectValue) where T : class
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(objectValue);
        }
    }
}