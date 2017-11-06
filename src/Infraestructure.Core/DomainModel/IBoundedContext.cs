namespace Infraestructure.Core.DomainModel
{
    public interface IBoundedContext
    {
        string Name { get; }
        string Description { get; }
    }
}