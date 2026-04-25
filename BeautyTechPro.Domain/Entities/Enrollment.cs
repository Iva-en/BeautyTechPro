using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int PracticeId { get; set; }
        public Practice Practice { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int ModalityId { get; set; }
        public Modality Modality { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}