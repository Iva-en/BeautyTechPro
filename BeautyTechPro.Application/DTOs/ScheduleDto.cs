using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Application.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }

        public int ModuleId { get; set; }
    }
}