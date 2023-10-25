using Microsoft.EntityFrameworkCore;
using ModuleProgram.Data.Context;
using ModuleProgram.Interfaces.Tagging;
using ModuleProgram.Models.Relation;

namespace ModuleProgram.Repositories.Tagging
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext _context;

        public UserRoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesByUserIdAsync(int userId)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserRole>> UpdateUserRolesAsync(IEnumerable<UserRole> existingUserRoles, IEnumerable<UserRole> updatedUserRoles)
        {
            // Remove existing user roles not in the updated list
            foreach (var existingUserRole in existingUserRoles.ToList())
            {
                if (!updatedUserRoles.Any(ur => ur.RoleId == existingUserRole.RoleId))
                {
                    _context.UserRoles.Remove(existingUserRole);
                }
            }

            // Add or update user roles in the updated list
            foreach (var updatedUserRole in updatedUserRoles)
            {
                var existingUserRole = existingUserRoles.FirstOrDefault(ur => ur.RoleId == updatedUserRole.RoleId);

                if (existingUserRole == null)
                {
                    _context.UserRoles.Add(updatedUserRole);
                }
            }

            await _context.SaveChangesAsync();
            return updatedUserRoles;
        }


    }
}
