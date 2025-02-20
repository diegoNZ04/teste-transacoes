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

        public async Task<IEnumerable<UserWithTradesResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.ListAllUsersAsync();

            return users.Select(user => new UserWithTradesResponse
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Trades = [.. user.Trades.Select(trade => new CreateNewTradeResponse
                {
                    Id = trade.Id,
                    Description = trade.Description,
                    Amount = trade.Amount,
                    Type = trade.Type,
                    UserId = trade.UserId
                })]
            }).ToList();
        }

        public async Task<UserWithTradesResponse> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.FindUserByIdAsync(userId);

            return new UserWithTradesResponse
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Trades = user.Trades.Select(trade => new CreateNewTradeResponse
                {
                    Id = trade.Id,
                    Description = trade.Description,
                    Amount = trade.Amount,
                    Type = trade.Type,
                    UserId = trade.UserId
                }).ToList()
            };
        }
    }
}