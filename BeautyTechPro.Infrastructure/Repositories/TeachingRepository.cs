using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class TeachingRepository
    {
        private readonly BeautyTechProContext context;

        public TeachingRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Teaching>> GetAllAsync()
        {
            return await context.Teachings
                .Include(t => t.Practices)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Student)
                .ToListAsync();
        }

        public async Task<Teaching> GetByIdAsync(int id)
        {
            return await context.Teachings
                .Include(t => t.Practices)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Teaching teaching)
        {
            context.Teachings.Add(teaching);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Teaching teaching)
        {
            context.Teachings.Update(teaching);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teaching = await context.Teachings.FindAsync(id);
            if (teaching != null)
            {
                context.Teachings.Remove(teaching);
                await context.SaveChangesAsync();
            }
        }
    }
}
