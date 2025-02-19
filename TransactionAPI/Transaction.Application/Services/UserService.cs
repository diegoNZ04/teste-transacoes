using Transaction.Application.Dtos.Responses;
using Transaction.Application.Services.Interfaces;
using Transaction.Domain.Entities;
using Transaction.Infra.Repositories.Interfaces;

namespace Transaction.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CreateNewUserResponse> CreateNewUserAsync(string name, int age)
        {
            var user = new User
            {
                Name = name,
                Age = age
            };

            await _userRepository.AddUserAsync(user);

            return new CreateNewUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age
            };
        }

        public async Task DeleteUserById(int userId)
        {
            var user = await _userRepository.FindUserByIdAsync(userId);

            if (user != null)
                await _userRepository.RemoveUserByIdAsync(user.Id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.ListAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.FindUserByIdAsync(userId);
        }
    }
}