using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Type { get; set; } // Matutino, Vespertino, Nocturno
    }
}
