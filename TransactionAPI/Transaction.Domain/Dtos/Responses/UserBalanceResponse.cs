namespace Transaction.Domain.Dtos.Responses
{
    public class UserBalanceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }
    }
}