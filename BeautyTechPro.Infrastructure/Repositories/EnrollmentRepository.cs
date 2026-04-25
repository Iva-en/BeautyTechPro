using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class EnrollmentRepository
    {
        private readonly BeautyTechProContext context;

        public EnrollmentRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Enrollment>> GetAllAsync()
        {
            return await context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Practice)
                    .ThenInclude(p => p.Teaching)
                .Include(e => e.Schedule)
                .Include(e => e.Modality)
                .Include(e => e.Payment)
                .ToListAsync();
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            return await context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Practice)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Enrollment enrollment)
        {
            context.Enrollments.Add(enrollment);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enrollment enrollment)
        {
            context.Enrollments.Update(enrollment);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var enrollment = await context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                context.Enrollments.Remove(enrollment);
                await context.SaveChangesAsync();
            }
        }
    }
}