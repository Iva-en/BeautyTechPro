using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class Practice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public int TeachingId { get; set; }
        public virtual Teaching Teaching { get; set; }

        public virtual ICollection<StudentPractice> StudentPractices { get; set; }
        public virtual ICollection<PracticeEquipment> PracticeEquipment { get; set; }
        public virtual ICollection<PracticeModule> PracticeModules { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}