using Transaction.Application.Dtos.Responses;
using Transaction.Domain.Entities;

namespace Transaction.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateNewUserResponse> CreateNewUserAsync(string name, int age);
        Task DeleteUserById(int userId);
        Task<List<User>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<User> GetUserByIdAsync(int userId);
    }
}