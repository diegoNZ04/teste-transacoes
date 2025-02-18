using Transaction.Application.Dtos.Responses;
using Transaction.Domain.Entities;
using Transaction.Domain.Enums;

namespace Transaction.Application.Services.Interfaces
{
    public interface ITradeService
    {
        Task<CreateNewTradeResponse> CreateNewTradeAsync(string description, decimal amount, int userId, TradeType Type);
        Task<List<Trade>> GetAllTradesAsync(int pageNumber, int pageSize);
        Task<Trade> GetTradeByIdAsync(int tradeId);
    }
}