using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class StudentRepository
    {
        private readonly BeautyTechProContext context;

        public StudentRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Practice)
                .Include(s => s.Attendances)
                .Include(s => s.Certificates)
                .Include(s => s.Comments)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Practice)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            context.Students.Update(student);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student != null)
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
            }
        }
    }
}