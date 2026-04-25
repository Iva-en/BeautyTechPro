using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        // FK Instructor
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        // Relationships
        public ICollection<Practice> Practices { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}