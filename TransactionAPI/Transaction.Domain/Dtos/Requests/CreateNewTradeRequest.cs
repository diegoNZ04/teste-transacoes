using Transaction.Domain.Enums;

namespace Transaction.Domain.Dtos.Requests
{
    public class CreateNewTradeRequest
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TradeType Type { get; set; }
        public int UserId { get; set; }
    }
}