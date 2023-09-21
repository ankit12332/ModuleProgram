using ModuleProgram.Models;

namespace ModuleProgram.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
