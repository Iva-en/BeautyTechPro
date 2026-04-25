using BeautyTechPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BeautyTechPro.Infrastructure.Data
{
    public class BeautyTechProContext : DbContext
    {
        public BeautyTechProContext(DbContextOptions<BeautyTechProContext> options) : base(options) { }

        public DbSet< Domain. Entities.Student> Students { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<StudentPractice> StudentPractices { get; set; }
        public DbSet<PracticeEquipment> PracticeEquipment { get; set; }
        public DbSet<PracticeModule> PracticeModules { get; set; }
    }
}