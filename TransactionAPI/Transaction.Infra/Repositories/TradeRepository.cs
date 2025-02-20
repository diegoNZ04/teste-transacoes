using Microsoft.EntityFrameworkCore;
using Transaction.Domain.Entities;
using Transaction.Infra.Data;
using Transaction.Infra.Repositories.Interfaces;

namespace Transaction.Infra.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly ApplicationDbContext _context;
        public TradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTradeAsync(Trade trade)
        {
            _context.Trades.Add(trade);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Trade>> ListAllTradesAsync()
        {
            return await _context.Trades.Include(t => t.User).ToListAsync();
        }

        public async Task<Trade> FindTradeByIdAsync(int id)
        {
            var trade = await _context.Trades.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);

            if (trade == null)
                throw new Exception("ID não encontrado");

            return trade;
        }
    }
}