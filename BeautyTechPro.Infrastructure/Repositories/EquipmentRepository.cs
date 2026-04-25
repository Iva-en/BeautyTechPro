using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class EquipmentRepository
    {
        private readonly BeautyTechProContext context;

        public EquipmentRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Equipment>> GetAllAsync()
        {
            return await context.Equipments
                .Include(e => e.PracticeEquipment)
                    .ThenInclude(pe => pe.Practice)
                .ToListAsync();
        }

        public async Task<Equipment> GetByIdAsync(int id)
        {
            return await context.Equipments
                .Include(e => e.PracticeEquipment)
                    .ThenInclude(pe => pe.Practice)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Equipment equipment)
        {
            context.Equipments.Add(equipment);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            context.Equipments.Update(equipment);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var equipment = await context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                context.Equipments.Remove(equipment);
                await context.SaveChangesAsync();
            }
        }
    }
}