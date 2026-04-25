using BeautyTechPro.Application.DTOs;
using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTechPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModulesController : ControllerBase
    {
        private readonly ModuleRepository _repository;

        public ModulesController(ModuleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modules = await _repository.GetAllAsync();

            var modulesDto = modules.Select(m => new ModuleDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Duration = m.Duration,
                InstructorId = m.InstructorId
            }).ToList();

            return Ok(modulesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var module = await _repository.GetByIdAsync(id);

            if (module == null)
                return NotFound();

            var moduleDto = new ModuleDto
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                Duration = module.Duration,
                InstructorId = module.InstructorId
            };

            return Ok(moduleDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModuleDto moduleDto)
        {
            var module = new Module
            {
                Name = moduleDto.Name,
                Description = moduleDto.Description,
                Duration = moduleDto.Duration,
                InstructorId = moduleDto.InstructorId
            };

            await _repository.AddAsync(module);

            moduleDto.Id = module.Id;

            return Ok(moduleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ModuleDto moduleDto)
        {
            if (id != moduleDto.Id)
                return BadRequest();

            var module = new Module
            {
                Id = moduleDto.Id,
                Name = moduleDto.Name,
                Description = moduleDto.Description,
                Duration = moduleDto.Duration,
                InstructorId = moduleDto.InstructorId
            };

            await _repository.UpdateAsync(module);

            return Ok(moduleDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}