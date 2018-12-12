namespace Sharing.Domain.Mappers
{
    public interface IMapper<T, DTO>
    {
        DTO AutoMap(T item);
        T ReAutoMap(DTO item, T initialItem);
    }
}
