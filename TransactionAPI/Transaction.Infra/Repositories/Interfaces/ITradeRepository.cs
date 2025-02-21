using Transaction.Domain.Dtos.Responses;
using Transaction.Domain.Entities;

namespace Transaction.Infra.Repositories.Interfaces
{
    public interface ITradeRepository
    {
        Task AddTradeAsync(Trade trade);
        Task<IEnumerable<Trade>> ListAllTradesAsync();
        Task<TradeWithUserIdResponse> FindTradeByIdAsync(int id);
    }
}