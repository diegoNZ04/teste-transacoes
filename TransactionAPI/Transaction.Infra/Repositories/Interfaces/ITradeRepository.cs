using Transaction.Domain.Entities;

namespace Transaction.Infra.Repositories.Interfaces
{
    public interface ITradeRepository
    {
        Task AddTradeAsync(Trade trade);
        Task<List<Trade>> GetAllTradesAsync(int pageNumber, int pageSize);
        Task<Trade> GetTradeByIdAsync(int id);
    }
}