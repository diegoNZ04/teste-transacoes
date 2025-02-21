using Transaction.Application.Services.Interfaces;
using Transaction.Domain.Dtos.Responses;
using Transaction.Domain.Entities;
using Transaction.Domain.Enums;
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

        public async Task<(IEnumerable<UserBalanceResponse> Users, SummaryResponse Summary)> GetAllUsersAsync()
        {
            var users = await _userRepository.ListAllUsersAsync();

            var usersBalance = users.Select(user => new UserBalanceResponse
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                TotalRevenue = user.Trades.Where(trade => trade.Type == TradeType.Revenue).Sum(trade => trade.Amount),
                TotalExpense = user.Trades.Where(trade => trade.Type == TradeType.Expense).Sum(trade => trade.Amount),
                Balance = user.Trades.Where(trade => trade.Type == TradeType.Revenue).Sum(trade => trade.Amount) -
                          user.Trades.Where(trade => trade.Type == TradeType.Expense).Sum(trade => trade.Amount)
            }).ToList();

            var summary = new SummaryResponse
            {
                TotalUsers = usersBalance.Count,
                TotalRevenue = usersBalance.Sum(u => u.TotalRevenue),
                TotalExpense = usersBalance.Sum(u => u.TotalExpense),
                TotalBalance = usersBalance.Sum(u => u.Balance)
            };

            return (usersBalance, summary);
        }

        public async Task<UserWithTradesResponse> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.FindUserByIdAsync(userId);

            if (user == null)
                return null;

            return user;
        }
    }
}