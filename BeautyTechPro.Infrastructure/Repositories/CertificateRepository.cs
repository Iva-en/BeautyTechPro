using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class CertificateRepository
    {
        private readonly BeautyTechProContext context;

        public CertificateRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Certificate>> GetAllAsync()
        {
            return await context.Certificates
                .Include(c => c.Student)
                .Include(c => c.Practice)
                    .ThenInclude(p => p.Teaching)
                .ToListAsync();
        }

        public async Task<Certificate> GetByIdAsync(int id)
        {
            return await context.Certificates
                .Include(c => c.Student)
                .Include(c => c.Practice)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Certificate certificate)
        {
            context.Certificates.Add(certificate);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Certificate certificate)
        {
            context.Certificates.Update(certificate);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var certificate = await context.Certificates.FindAsync(id);
            if (certificate != null)
            {
                context.Certificates.Remove(certificate);
                await context.SaveChangesAsync();
            }
        }
    }
}