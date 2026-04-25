using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class PracticeRepository
    {
        private readonly BeautyTechProContext context;

        public PracticeRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Practice>> GetAllAsync()
        {
            return await context.Practices
                .Include(p => p.Teaching)
                .Include(p => p.PracticeEquipment)
                    .ThenInclude(pe => pe.Equipment)
                .Include(p => p.PracticeModules)
                    .ThenInclude(pm => pm.Module)
                .ToListAsync();
        }

        public async Task<Practice> GetByIdAsync(int id)
        {
            return await context.Practices
                .Include(p => p.Teaching)
                .Include(p => p.PracticeEquipment)
                    .ThenInclude(pe => pe.Equipment)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Practice practice)
        {
            context.Practices.Add(practice);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Practice practice)
        {
            context.Practices.Update(practice);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var practice = await context.Practices.FindAsync(id);
            if (practice != null)
            {
                context.Practices.Remove(practice);
                await context.SaveChangesAsync();
            }
        }
    }
}