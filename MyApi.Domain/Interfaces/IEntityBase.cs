namespace MyApi.Domain.Interfaces
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
