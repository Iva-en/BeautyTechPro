using BeautyTechPro.Infrastructure.Data;

namespace BeautyTechPro.Infrastructure.Repositories
{
    public class UnitOfWork
    {
        private readonly BeautyTechProContext context;

        public StudentRepository Students { get; }
        public TeachingRepository Teachings { get; }
        public PracticeRepository Practices { get; }
        public EnrollmentRepository Enrollments { get; }
        public PaymentRepository Payments { get; }
        public AttendanceRepository Attendances { get; }
        public CertificateRepository Certificates { get; }
        public CommentRepository Comments { get; }
        public EquipmentRepository Equipments { get; }

        public UnitOfWork(BeautyTechProContext context)
        {
            this.context = context;
            Students = new StudentRepository(context);
            Teachings = new TeachingRepository(context);
            Practices = new PracticeRepository(context);
            Enrollments = new EnrollmentRepository(context);
            Payments = new PaymentRepository(context);
            Attendances = new AttendanceRepository(context);
            Certificates = new CertificateRepository(context);
            Comments = new CommentRepository(context);
            Equipments = new EquipmentRepository(context);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync ();
        }
    }
}