using Transaction.Application.Dtos.Responses;
using Transaction.Domain.Entities;

namespace Transaction.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateNewUserResponse> CreateNewUserAsync(string name, int age);
        Task DeleteUserById(int userId);
        Task<IEnumerable<UserWithTradesResponse>> GetAllUsersAsync();
        Task<UserWithTradesResponse> GetUserByIdAsync(int userId);
    }
}