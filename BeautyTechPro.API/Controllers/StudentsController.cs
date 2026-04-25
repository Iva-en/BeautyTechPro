using BeautyTechPro.Application.DTOs;
using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTechPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentRepository _repository;

        public StudentsController(StudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _repository.GetAllAsync();

            var studentsDto = students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                RegistrationDate = s.RegistrationDate
            }).ToList();

            return Ok(studentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            var studentDto = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                RegistrationDate = student.RegistrationDate
            };

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                RegistrationDate = studentDto.RegistrationDate
            };

            await _repository.AddAsync(student);

            studentDto.Id = student.Id;

            return Ok(studentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDto studentDto)
        {
            if (id != studentDto.Id)
                return BadRequest();

            var student = new Student
            {
                Id = studentDto.Id,
                Name = studentDto.Name,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                RegistrationDate = studentDto.RegistrationDate
            };

            await _repository.UpdateAsync(student);

            return Ok(studentDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}