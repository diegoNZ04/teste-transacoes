using Transaction.Domain.Entities;

namespace Transaction.Infra.Repositories.Interfaces
{
    public interface ITradeRepository
    {
        Task AddTradeAsync(Trade trade);
        Task<List<Trade>> ListAllTradesAsync(int pageNumber, int pageSize);
        Task<Trade> FindUserByIdAsync(int id);
    }
}