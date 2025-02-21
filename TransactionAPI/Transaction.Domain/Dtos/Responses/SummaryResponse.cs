namespace Transaction.Domain.Dtos.Responses
{
    public class SummaryResponse
    {
        public int TotalUsers { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalBalance { get; set; }
    }
}