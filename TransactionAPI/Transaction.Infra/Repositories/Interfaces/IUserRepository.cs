using Transaction.Domain.Entities;

namespace Transaction.Infra.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task RemoveUserByIdAsync(int id);
        Task<List<User>> ListAllUsersAsync(int pageNumber, int pageSize);
        Task<User> FindUserByIdAsync(int id);
    }
}