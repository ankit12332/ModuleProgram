using ModuleProgram.Dtos;
using ModuleProgram.Models;

namespace ModuleProgram.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Permission> GetPermissionAsync(int id);
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> CreatePermissionAsync(PermissionDto permissionDto);
        Task<Permission> UpdatePermissionAsync(int id, PermissionDto permissionDto);
        Task<bool> DeletePermissionAsync(int id);
    }
}
