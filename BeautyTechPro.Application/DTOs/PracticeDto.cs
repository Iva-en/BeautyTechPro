using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Application.DTOs
{
    public class PracticeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Grade { get; set; }
        public string Observations { get; set; }

        public int StudentId { get; set; }
        public int ModuleId { get; set; }
        public int InstructorId { get; set; }
    }
}