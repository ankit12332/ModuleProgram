﻿using Microsoft.EntityFrameworkCore;
using ModuleProgram.Context;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return new User();
            }

            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
