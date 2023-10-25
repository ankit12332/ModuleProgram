using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleProgram.Dtos;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModules()
        {
            var modules = await _moduleRepository.GetAllModulesAsync();
            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModuleById(int id)
        {
            var module = await _moduleRepository.GetModuleByIdAsync(id);

            if (module == null)
            {
                return NotFound(); // Module not found
            }

            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModule([FromBody] ModuleDto moduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var module = new Module
            {
                ModuleName = moduleDto.ModuleName
            };

            var createdModule = await _moduleRepository.CreateModuleAsync(module);

            return CreatedAtAction(nameof(GetModuleById), new { id = createdModule.Id }, createdModule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, [FromBody] ModuleDto moduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var module = new Module
            {
                ModuleName = moduleDto.ModuleName
            };

            var updated = await _moduleRepository.UpdateModuleAsync(id, module);

            if (!updated)
            {
                return NotFound(); // Module not found
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var deleted = await _moduleRepository.DeleteModuleAsync(id);

            if (!deleted)
            {
                return NotFound(); // Module not found
            }

            return NoContent();
        }
    }
}
