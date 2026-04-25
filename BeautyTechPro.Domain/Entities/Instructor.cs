using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }

        // Relationships
        public ICollection<Module> Modules { get; set; }
        public ICollection<Practice> Practices { get; set; }
    }
}