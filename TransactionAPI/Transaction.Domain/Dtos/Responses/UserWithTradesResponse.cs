namespace Transaction.Domain.Dtos.Responses
{
    public class UserWithTradesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public List<CreateNewTradeResponse> Trades { get; set; } = new List<CreateNewTradeResponse>();
    }
}