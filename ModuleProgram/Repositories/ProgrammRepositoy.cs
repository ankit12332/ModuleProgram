using Microsoft.EntityFrameworkCore;
using ModuleProgram.Data.Context;
using ModuleProgram.Dtos;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Repositories
{
    public class ProgrammRepository : IProgrammRepository
    {
        private readonly AppDbContext _context;

        public ProgrammRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Programm>> GetAllProgrammsAsync()
        {
            return await _context.Programms.ToListAsync();
        }

        public async Task<Programm> GetProgrammByIdAsync(int id)
        {
            return await _context.Programms.FindAsync(id);
        }

        public async Task<Programm> CreateProgrammAsync(ProgrammDto programmDto)
        {
            var programm = new Programm
            {
                ProgrammName = programmDto.ProgrammName,
            };

            _context.Programms.Add(programm);
            await _context.SaveChangesAsync();

            return programm;
        }

        public async Task<Programm> UpdateProgrammAsync(int id, ProgrammDto programmDto)
        {
            var existingProgramm = await _context.Programms.FindAsync(id);

            if (existingProgramm == null)
            {
                return null; // or handle the not found case as needed
            }

            existingProgramm.ProgrammName = programmDto.ProgrammName;

            await _context.SaveChangesAsync();

            return existingProgramm;
        }

        public async Task<bool> DeleteProgrammAsync(int id)
        {
            var programm = await _context.Programms.FindAsync(id);

            if (programm == null)
            {
                return false;
            }

            _context.Programms.Remove(programm);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
