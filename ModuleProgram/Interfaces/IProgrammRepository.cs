using ModuleProgram.Dtos;
using ModuleProgram.Models;

namespace ModuleProgram.Interfaces
{
    public interface IProgrammRepository
    {
        Task<IEnumerable<Programm>> GetAllProgrammsAsync();
        Task<Programm> GetProgrammByIdAsync(int id);
        Task<Programm> CreateProgrammAsync(ProgrammDto programmDto);
        Task<Programm> UpdateProgrammAsync(int id, ProgrammDto programmDto);
        Task<bool> DeleteProgrammAsync(int id);
    }
}
