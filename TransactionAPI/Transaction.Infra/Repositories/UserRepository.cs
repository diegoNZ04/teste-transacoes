using Microsoft.EntityFrameworkCore;
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

        public async Task<User> FindUserByIdAsync(int id)
        {
            var user = await _context.Users.Include(u => u.Trades).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception("ID não encontrado");

            return user;
        }
    }
}