using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class PaymentRepository
    {
        private readonly BeautyTechProContext context;

        public PaymentRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await context.Payments
                .Include(p => p.Enrollment)
                    .ThenInclude(e => e.Student)
                .ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await context.Payments
                .Include(p => p.Enrollment)
                    .ThenInclude(e => e.Student)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Payment payment)
        {
            context.Payments.Add(payment);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Payment payment)
        {
            context.Payments.Update(payment);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await context.Payments.FindAsync(id);
            if (payment != null)
            {
                context.Payments.Remove(payment);
                await context.SaveChangesAsync();
            }
        }
    }
}