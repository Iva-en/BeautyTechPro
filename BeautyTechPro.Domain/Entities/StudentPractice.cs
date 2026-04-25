using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class StudentPractice
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int PracticeId { get; set; }
        public Practice Practice { get; set; }
    }
}
