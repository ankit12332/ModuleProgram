﻿using ModuleProgram.Models;

namespace ModuleProgram.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);

        Task<User?> GetUserByUsernameAsync(string username);
    }
}
