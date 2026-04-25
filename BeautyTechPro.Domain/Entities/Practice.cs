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
        public DateTime Date { get; set; }
        public decimal Grade { get; set; }
        public string Observations { get; set; }

        // FK Student
        public int StudentId { get; set; }
        public Student Student { get; set; }

        // FK Module
        public int ModuleId { get; set; }
        public Module Module { get; set; }

        // FK Instructor
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}