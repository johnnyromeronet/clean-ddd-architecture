namespace Clean.DDD.Architecture.Domain.Contracts.Services
{
    public interface IHealthcheckService
    {
        Task<string> GetDatabaseStatus();
    }
}
