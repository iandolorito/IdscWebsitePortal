using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraries.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
        public string Payment_Method { get; set; }

        [Column(TypeName = "decimal(10, 2")]
        public decimal Payment_Ammount { get; set; }
        
    }
}
