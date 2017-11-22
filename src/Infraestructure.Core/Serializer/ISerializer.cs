namespace Infraestructure.Core.Serializer
{
    public interface ISerializer
    {
        string Serialize(object @object);
        T Deserialize<T>(string objectValue) where T : class;
    }
}