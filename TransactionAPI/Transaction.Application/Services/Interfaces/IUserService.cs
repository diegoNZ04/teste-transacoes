using Transaction.Domain.Dtos.Responses;

namespace Transaction.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateNewUserResponse> CreateNewUserAsync(string name, int age);
        Task DeleteUserById(int userId);
        Task<(IEnumerable<UserBalanceResponse> Users, SummaryResponse Summary)> GetAllUsersAsync();
        Task<UserWithTradesResponse> GetUserByIdAsync(int userId);
    }
}