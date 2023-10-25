using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleProgram.Dtos;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammController : ControllerBase
    {
        private readonly IProgrammRepository _programmRepository;

        public ProgrammController(IProgrammRepository programmRepository)
        {
            _programmRepository = programmRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programm>>> GetProgramms()
        {
            var programms = await _programmRepository.GetAllProgrammsAsync();
            return Ok(programms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Programm>> GetProgramm(int id)
        {
            var programm = await _programmRepository.GetProgrammByIdAsync(id);

            if (programm == null)
            {
                return NotFound();
            }

            return Ok(programm);
        }

        [HttpPost]
        public async Task<ActionResult<Programm>> CreateProgramm(ProgrammDto programmDto)
        {
            var createdProgramm = await _programmRepository.CreateProgrammAsync(programmDto);
            return CreatedAtAction("GetProgramm", new { id = createdProgramm.Id }, createdProgramm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Programm>> UpdateProgramm(int id, ProgrammDto programmDto)
        {
            var updatedProgramm = await _programmRepository.UpdateProgrammAsync(id, programmDto);

            if (updatedProgramm == null)
            {
                return NotFound();
            }

            return Ok(updatedProgramm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProgramm(int id)
        {
            var deleted = await _programmRepository.DeleteProgrammAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
