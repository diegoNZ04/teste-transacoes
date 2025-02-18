using Transaction.Domain.Entities;

namespace Transaction.Infra.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task DeleteUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<User> GetUserByIdAsync(int id);
    }
}