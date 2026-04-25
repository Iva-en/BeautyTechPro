using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyTechPro.Domain.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string VerificationCode { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int PracticeId { get; set; }
        public Practice Practice { get; set; }
    }
}
