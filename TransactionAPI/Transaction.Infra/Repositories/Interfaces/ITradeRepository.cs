using Transaction.Domain.Entities;

namespace Transaction.Infra.Repositories.Interfaces
{
    public interface ITradeRepository
    {
        Task AddTradeAsync(Trade trade);
        Task<IEnumerable<Trade>> ListAllTradesAsync();
        Task<Trade> FindTradeByIdAsync(int id);
    }
}