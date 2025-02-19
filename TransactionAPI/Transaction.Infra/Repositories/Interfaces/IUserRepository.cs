using Transaction.Domain.Entities;

namespace Transaction.Infra.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task RemoveUserByIdAsync(int id);
        Task<IEnumerable<User>> ListAllUsersAsync();
        Task<User> FindUserByIdAsync(int id);
    }
}