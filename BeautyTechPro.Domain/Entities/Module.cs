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
        public int Duration { get; set; } // tiempo en horas
        public virtual ICollection<PracticeModule> PracticeModules { get; set; }

    }
}
