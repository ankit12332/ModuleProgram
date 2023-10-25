using Microsoft.EntityFrameworkCore;
using ModuleProgram.Data.Context;
using ModuleProgram.Dtos;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Permission> GetPermissionAsync(int id)
        {
            return await _context.Permissions.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<Permission> CreatePermissionAsync(PermissionDto permissionDto)
        {
            var permission = new Permission
            {
                PermissionName = permissionDto.PermissionName,
                Description = permissionDto.Description
            };

            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<Permission> UpdatePermissionAsync(int id, PermissionDto permissionDto)
        {
            var existingPermission = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == id);

            if (existingPermission == null)
            {
                throw new Exception("Permission not found");
            }

            existingPermission.PermissionName = permissionDto.PermissionName;
            existingPermission.Description = permissionDto.Description;

            await _context.SaveChangesAsync();
            return existingPermission;
        }

        public async Task<bool> DeletePermissionAsync(int id)
        {
            var existingPermission = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == id);

            if (existingPermission == null)
            {
                return false; // Permission not found
            }

            _context.Permissions.Remove(existingPermission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}