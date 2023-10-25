using Microsoft.EntityFrameworkCore;
using ModuleProgram.Data.Context;
using ModuleProgram.Dtos;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly AppDbContext _context;

        public ModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<Module> GetModuleByIdAsync(int id)
        {
            return await _context.Modules.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Module> CreateModuleAsync(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<bool> UpdateModuleAsync(int id, Module module)
        {
            var existingModule = await _context.Modules.FirstOrDefaultAsync(m => m.Id == id);

            if (existingModule == null)
            {
                return false; // Module not found
            }

            existingModule.ModuleName = module.ModuleName;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteModuleAsync(int id)
        {
            var module = await _context.Modules.FirstOrDefaultAsync(m => m.Id == id);

            if (module == null)
            {
                return false; // Module not found
            }

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
