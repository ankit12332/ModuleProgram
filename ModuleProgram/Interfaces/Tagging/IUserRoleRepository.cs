using ModuleProgram.Models.Relation;

namespace ModuleProgram.Interfaces.Tagging
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetUserRolesByUserIdAsync(int userId);
        Task<IEnumerable<UserRole>> UpdateUserRolesAsync(IEnumerable<UserRole> existingUserRoles, IEnumerable<UserRole> updatedUserRoles);
    }
}
