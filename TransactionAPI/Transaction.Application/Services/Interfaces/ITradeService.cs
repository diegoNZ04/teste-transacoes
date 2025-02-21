using Transaction.Domain.Dtos.Responses;
using Transaction.Domain.Enums;

namespace Transaction.Application.Services.Interfaces
{
    public interface ITradeService
    {
        Task<CreateNewTradeResponse> CreateNewTradeAsync(string description, decimal amount, int userId, TradeType Type);
        Task<IEnumerable<TradeWithUserIdResponse>> GetAllTradesAsync();
        Task<TradeWithUserIdResponse> GetTradeByIdAsync(int tradeId);
    }
}