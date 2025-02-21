using Transaction.Domain.Dtos.Responses;
using Transaction.Application.Services.Interfaces;
using Transaction.Domain.Entities;
using Transaction.Domain.Enums;
using Transaction.Infra.Repositories.Interfaces;

namespace Transaction.Application.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }
        public async Task<CreateNewTradeResponse> CreateNewTradeAsync(string description, decimal amount, int userId, TradeType Type)
        {
            var trade = new Trade
            {
                Description = description,
                Amount = amount,
                UserId = userId,
                Type = Type
            };

            await _tradeRepository.AddTradeAsync(trade);

            return new CreateNewTradeResponse
            {
                Id = trade.Id,
                Description = trade.Description,
                Amount = trade.Amount,
                UserId = trade.UserId,
                Type = trade.Type
            };
        }

        public async Task<IEnumerable<TradeWithUserIdResponse>> GetAllTradesAsync()
        {
            var trades = await _tradeRepository.ListAllTradesAsync();

            var tradesFormat = trades.Select(trade => new TradeWithUserIdResponse
            {
                Id = trade.Id,
                Description = trade.Description,
                Amount = trade.Amount,
                Type = trade.Type,
                UserId = trade.UserId
            }).ToList();

            return tradesFormat;
        }

        public async Task<TradeWithUserIdResponse> GetTradeByIdAsync(int tradeId)
        {
            var trade = await _tradeRepository.FindTradeByIdAsync(tradeId);

            if (trade == null)
                return null;

            return trade;
        }
    }
}