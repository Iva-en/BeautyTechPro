using BeautyTechPro.Domain.Entities;
using BeautyTechPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class CommentRepository
    {
        private readonly BeautyTechProContext context;

        public CommentRepository(BeautyTechProContext context)
        {
            this.context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await context.Comments
                .Include(c => c.Student)
                .Include(c => c.Teaching)
                .ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await context.Comments
                .Include(c => c.Student)
                .Include(c => c.Teaching)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Comment comment)
        {
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            context.Comments.Update(comment);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await context.Comments.FindAsync(id);
            if (comment != null)
            {
                context.Comments.Remove(comment);
                await context.SaveChangesAsync();
            }
        }
    }
}