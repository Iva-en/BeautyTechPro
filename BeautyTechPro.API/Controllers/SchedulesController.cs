using BeautyTechPro.Application.DTOs;
using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTechPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly ScheduleRepository _repository;

        public SchedulesController(ScheduleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _repository.GetAllAsync();

            var schedulesDto = schedules.Select(s => new ScheduleDto
            {
                Id = s.Id,
                Date = s.Date,
                Time = s.Time,
                ModuleId = s.ModuleId
            }).ToList();

            return Ok(schedulesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var schedule = await _repository.GetByIdAsync(id);

            if (schedule == null)
                return NotFound();

            var scheduleDto = new ScheduleDto
            {
                Id = schedule.Id,
                Date = schedule.Date,
                Time = schedule.Time,
                ModuleId = schedule.ModuleId
            };

            return Ok(scheduleDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScheduleDto scheduleDto)
        {
            var schedule = new Schedule
            {
                Date = scheduleDto.Date,
                Time = scheduleDto.Time,
                ModuleId = scheduleDto.ModuleId
            };

            await _repository.AddAsync(schedule);

            scheduleDto.Id = schedule.Id;

            return Ok(scheduleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ScheduleDto scheduleDto)
        {
            if (id != scheduleDto.Id)
                return BadRequest();

            var schedule = new Schedule
            {
                Id = scheduleDto.Id,
                Date = scheduleDto.Date,
                Time = scheduleDto.Time,
                ModuleId = scheduleDto.ModuleId
            };

            await _repository.UpdateAsync(schedule);

            return Ok(scheduleDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}