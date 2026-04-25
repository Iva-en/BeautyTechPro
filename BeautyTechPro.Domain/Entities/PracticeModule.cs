using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class PracticeModule
    {
        public int PracticeId { get; set; }
        public Practice Practice { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
