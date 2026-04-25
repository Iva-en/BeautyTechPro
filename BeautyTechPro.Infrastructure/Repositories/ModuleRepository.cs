using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class ModuleRepository
    {
        private readonly BeautyTechProContext _context;

        public ModuleRepository(BeautyTechProContext context)
        {
            _context = context;
        }

        public async Task<List<Module>> GetAllAsync()
        {
            return await _context.Modules
                .Include(m => m.Instructor)
                .ToListAsync();
        }

        public async Task<Module> GetByIdAsync(int id)
        {
            return await _context.Modules
                .Include(m => m.Instructor)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Module module)
        {
            await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Module module)
        {
            _context.Modules.Update(module);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module != null)
            {
                _context.Modules.Remove(module);
                await _context.SaveChangesAsync();
            }
        }
    }
}