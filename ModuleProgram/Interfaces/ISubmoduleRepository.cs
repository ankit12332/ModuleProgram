using ModuleProgram.Models;

namespace ModuleProgram.Interfaces
{
    public interface ISubmoduleRepository
    {
        Task<IEnumerable<Submodule>> GetSubmodulesAsync();
        Task<Submodule> GetSubmoduleByIdAsync(int id);
        Task<Submodule> CreateSubmoduleAsync(Submodule submodule);
        Task<Submodule> UpdateSubmoduleAsync(int id, Submodule submodule);
        Task<bool> DeleteSubmoduleAsync(int id);
    }
}
