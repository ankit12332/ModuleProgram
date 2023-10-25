using Microsoft.EntityFrameworkCore;
using ModuleProgram.Data.Context;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;
using ModuleProgram.Models.Relation;

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
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .AsNoTracking()
                .Select(u => new User
                {
                    Id = u.Id,
                    Name = u.Name,
                    Username = u.Username,
                    Password = u.Password,
                    CreatedAt = u.CreatedAt,
                    UserRoles = u.UserRoles.Select(ur => new UserRole
                    {
                        Role = new Role
                        {
                            Id = ur.Role.Id,
                            RoleName = ur.Role.RoleName,
                            Description = ur.Role.Description,
                            UserRoles = null, // Exclude userRoles property
                            RolePermissions = null // Exclude rolePermissions property
                        }
                    }).ToList()
                })
                .ToListAsync();
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
