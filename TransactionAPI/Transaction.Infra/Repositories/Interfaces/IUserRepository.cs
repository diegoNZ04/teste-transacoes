using Transaction.Domain.Dtos.Responses;
using Transaction.Domain.Entities;

namespace Transaction.Infra.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task RemoveUserByIdAsync(int id);
        Task<IEnumerable<User>> ListAllUsersAsync();
        Task<UserWithTradesResponse> FindUserByIdAsync(int id);
    }
}