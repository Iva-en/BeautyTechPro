using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Useguide { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Unit { get; set; } // unidad, ml, gr
        public virtual  ICollection<PracticeEquipment> PracticeEquipment{ get; set; }
    }
}
