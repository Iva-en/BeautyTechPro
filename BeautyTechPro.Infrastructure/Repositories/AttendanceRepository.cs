using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class AttendanceRepository
    {
        private readonly BeautyTechProContext context;

        public AttendanceRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
            return await context.Attendances
                .Include(a => a.Student)
                .ToListAsync();
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            return await context.Attendances
                .Include(a => a.Student)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Attendance attendance)
        {
            context.Attendances.Add(attendance);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            context.Attendances.Update(attendance);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attendance = await context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                context.Attendances.Remove(attendance);
                await context.SaveChangesAsync();
            }
        }
    }
}