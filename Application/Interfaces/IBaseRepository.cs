namespace Application.Interfaces
{
    public interface IBaseRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
