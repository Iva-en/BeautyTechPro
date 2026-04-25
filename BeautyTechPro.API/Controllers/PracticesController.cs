using BeautyTechPro.Application.DTOs;
using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTechPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PracticesController : ControllerBase
    {
        private readonly PracticeRepository _repository;

        public PracticesController(PracticeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var practices = await _repository.GetAllAsync();

            var practicesDto = practices.Select(p => new PracticeDto
            {
                Id = p.Id,
                Name = p.Name,
                Date = p.Date,
                Grade = p.Grade,
                Observations = p.Observations,
                StudentId = p.StudentId,
                ModuleId = p.ModuleId,
                InstructorId = p.InstructorId
            }).ToList();

            return Ok(practicesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var practice = await _repository.GetByIdAsync(id);

            if (practice == null)
                return NotFound();

            var practiceDto = new PracticeDto
            {
                Id = practice.Id,
                Name = practice.Name,
                Date = practice.Date,
                Grade = practice.Grade,
                Observations = practice.Observations,
                StudentId = practice.StudentId,
                ModuleId = practice.ModuleId,
                InstructorId = practice.InstructorId
            };

            return Ok(practiceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PracticeDto practiceDto)
        {
            var practice = new Practice
            {
                Name = practiceDto.Name,
                Date = practiceDto.Date,
                Grade = practiceDto.Grade,
                Observations = practiceDto.Observations,
                StudentId = practiceDto.StudentId,
                ModuleId = practiceDto.ModuleId,
                InstructorId = practiceDto.InstructorId
            };

            await _repository.AddAsync(practice);

            practiceDto.Id = practice.Id;

            return Ok(practiceDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PracticeDto practiceDto)
        {
            if (id != practiceDto.Id)
                return BadRequest();

            var practice = new Practice
            {
                Id = practiceDto.Id,
                Name = practiceDto.Name,
                Date = practiceDto.Date,
                Grade = practiceDto.Grade,
                Observations = practiceDto.Observations,
                StudentId = practiceDto.StudentId,
                ModuleId = practiceDto.ModuleId,
                InstructorId = practiceDto.InstructorId
            };

            await _repository.UpdateAsync(practice);

            return Ok(practiceDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}