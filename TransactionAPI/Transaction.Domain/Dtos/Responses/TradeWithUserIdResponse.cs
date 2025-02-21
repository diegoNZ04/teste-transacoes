using Transaction.Domain.Entities;
using Transaction.Domain.Enums;

namespace Transaction.Domain.Dtos.Responses
{
    public class TradeWithUserIdResponse
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TradeType Type { get; set; }
        public int UserId { get; set; }
    }
}