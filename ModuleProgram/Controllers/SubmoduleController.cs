using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleProgram.Dtos;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmoduleController : ControllerBase
    {
        private readonly ISubmoduleRepository _submoduleRepository;

        public SubmoduleController(ISubmoduleRepository submoduleRepository)
        {
            _submoduleRepository = submoduleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubmodules()
        {
            var submodules = await _submoduleRepository.GetSubmodulesAsync();
            return Ok(submodules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubmodule(int id)
        {
            var submodule = await _submoduleRepository.GetSubmoduleByIdAsync(id);
            if (submodule == null)
            {
                return NotFound();
            }
            return Ok(submodule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubmodule([FromBody] SubmoduleDto submoduleDto)
        {
            var submodule = new Submodule
            {
                SubmoduleName = submoduleDto.SubmoduleName
            };

            var createdSubmodule = await _submoduleRepository.CreateSubmoduleAsync(submodule);
            return CreatedAtAction(nameof(GetSubmodule), new { id = createdSubmodule.Id }, createdSubmodule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubmodule(int id, [FromBody] SubmoduleDto submoduleDto)
        {
            var submodule = new Submodule
            {
                SubmoduleName = submoduleDto.SubmoduleName,
            };

            var updatedSubmodule = await _submoduleRepository.UpdateSubmoduleAsync(id, submodule);
            if (updatedSubmodule == null)
            {
                return NotFound();
            }
            return Ok(updatedSubmodule);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmodule(int id)
        {
            var result = await _submoduleRepository.DeleteSubmoduleAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
