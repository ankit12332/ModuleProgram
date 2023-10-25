using Microsoft.EntityFrameworkCore;
using ModuleProgram.Data.Context;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Repositories
{
    public class SubmoduleRepository : ISubmoduleRepository
    {
        private readonly AppDbContext _context;

        public SubmoduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Submodule>> GetSubmodulesAsync()
        {
            return await _context.Submodules.ToListAsync();
        }

        public async Task<Submodule> GetSubmoduleByIdAsync(int id)
        {
            return await _context.Submodules.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Submodule> CreateSubmoduleAsync(Submodule submodule)
        {
            _context.Submodules.Add(submodule);
            await _context.SaveChangesAsync();
            return submodule;
        }

        public async Task<Submodule> UpdateSubmoduleAsync(int id, Submodule submodule)
        {
            var existingSubmodule = await _context.Submodules.FirstOrDefaultAsync(s => s.Id == id);

            if (existingSubmodule != null)
            {
                existingSubmodule.SubmoduleName = submodule.SubmoduleName;
                existingSubmodule.ModuleId = submodule.ModuleId;

                await _context.SaveChangesAsync();
            }

            return existingSubmodule;
        }

        public async Task<bool> DeleteSubmoduleAsync(int id)
        {
            var submodule = await _context.Submodules.FirstOrDefaultAsync(s => s.Id == id);

            if (submodule != null)
            {
                _context.Submodules.Remove(submodule);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
