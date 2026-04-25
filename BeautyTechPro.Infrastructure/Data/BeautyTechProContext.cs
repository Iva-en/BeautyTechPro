using Microsoft.EntityFrameworkCore;
using BeautyTechPro.Domain.Entities;

namespace BeautyTechPro.Infrastructure.Data
{
    public class BeautyTechProContext : DbContext
    {
        public BeautyTechProContext(DbContextOptions<BeautyTechProContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Practice>()
                .Property(p => p.Grade)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Practice>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Practices)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Practice>()
                .HasOne(p => p.Module)
                .WithMany(m => m.Practices)
                .HasForeignKey(p => p.ModuleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Practice>()
                .HasOne(p => p.Instructor)
                .WithMany(i => i.Practices)
                .HasForeignKey(p => p.InstructorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}