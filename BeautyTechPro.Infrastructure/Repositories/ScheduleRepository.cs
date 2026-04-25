using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class ScheduleRepository
    {
        private readonly BeautyTechProContext _context;

        public ScheduleRepository(BeautyTechProContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GetAllAsync()
        {
            return await _context.Schedules
                .Include(s => s.Module)
                .ToListAsync();
        }

        public async Task<Schedule> GetByIdAsync(int id)
        {
            return await _context.Schedules
                .Include(s => s.Module)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();
            }
        }
    }
}