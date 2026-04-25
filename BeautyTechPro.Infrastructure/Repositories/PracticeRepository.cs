using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class PracticeRepository
    {
        private readonly BeautyTechProContext _context;

        public PracticeRepository(BeautyTechProContext context)
        {
            _context = context;
        }

        public async Task<List<Practice>> GetAllAsync()
        {
            return await _context.Practices
                .Include(p => p.Student)
                .Include(p => p.Module)
                .Include(p => p.Instructor)
                .ToListAsync();
        }

        public async Task<Practice> GetByIdAsync(int id)
        {
            return await _context.Practices
                .Include(p => p.Student)
                .Include(p => p.Module)
                .Include(p => p.Instructor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Practice practice)
        {
            await _context.Practices.AddAsync(practice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Practice practice)
        {
            _context.Practices.Update(practice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var practice = await _context.Practices.FindAsync(id);
            if (practice != null)
            {
                _context.Practices.Remove(practice);
                await _context.SaveChangesAsync();
            }
        }
    }
}