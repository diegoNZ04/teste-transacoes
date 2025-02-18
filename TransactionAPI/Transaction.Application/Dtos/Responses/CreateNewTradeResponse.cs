using Transaction.Domain.Enums;

namespace Transaction.Application.Dtos.Responses
{
    public class CreateNewTradeResponse
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TradeType Type { get; set; }
        public int UserId { get; set; }
    }
}