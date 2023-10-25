using ModuleProgram.Models;

namespace ModuleProgram.Interfaces
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetAllModulesAsync();
        Task<Module> GetModuleByIdAsync(int id);
        Task<Module> CreateModuleAsync(Module module);
        Task<bool> UpdateModuleAsync(int id, Module module);
        Task<bool> DeleteModuleAsync(int id);
    }
}
