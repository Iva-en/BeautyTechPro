using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Method { get; set; } // Efectivo, Transferencia, Tarjeta
        public string Status { get; set; } // Pagado, Pendiente, Parcial
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
