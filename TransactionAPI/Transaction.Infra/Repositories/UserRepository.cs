using Microsoft.EntityFrameworkCore;
using Transaction.Domain.Dtos.Responses;
using Transaction.Domain.Entities;
using Transaction.Infra.Data;
using Transaction.Infra.Repositories.Interfaces;

namespace Transaction.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> ListAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Trades).ToListAsync();
        }

        public async Task<UserWithTradesResponse> FindUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Trades)
                .Where(u => u.Id == id)
                .Select(u => new UserWithTradesResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Age = u.Age,
                    Trades = u.Trades.Select(t => new CreateNewTradeResponse
                    {
                        Id = t.Id,
                        Description = t.Description,
                        Amount = t.Amount,
                        Type = t.Type,
                        UserId = t.UserId
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User Not Found.");
            }

            return user;
        }
    }
}