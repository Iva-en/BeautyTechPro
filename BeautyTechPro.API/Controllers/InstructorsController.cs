using BeautyTechPro.Application.DTOs;
using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTechPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly InstructorRepository _repository;

        public InstructorsController(InstructorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var instructors = await _repository.GetAllAsync();

            var instructorsDto = instructors.Select(i => new InstructorDto
            {
                Id = i.Id,
                Name = i.Name,
                Specialty = i.Specialty,
                Email = i.Email
            }).ToList();

            return Ok(instructorsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var instructor = await _repository.GetByIdAsync(id);

            if (instructor == null)
                return NotFound();

            var instructorDto = new InstructorDto
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Specialty = instructor.Specialty,
                Email = instructor.Email
            };

            return Ok(instructorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InstructorDto instructorDto)
        {
            var instructor = new Instructor
            {
                Name = instructorDto.Name,
                Specialty = instructorDto.Specialty,
                Email = instructorDto.Email
            };

            await _repository.AddAsync(instructor);

            instructorDto.Id = instructor.Id;

            return Ok(instructorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InstructorDto instructorDto)
        {
            if (id != instructorDto.Id)
                return BadRequest();

            var instructor = new Instructor
            {
                Id = instructorDto.Id,
                Name = instructorDto.Name,
                Specialty = instructorDto.Specialty,
                Email = instructorDto.Email
            };

            await _repository.UpdateAsync(instructor);

            return Ok(instructorDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}