namespace Dev.Challenge.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
