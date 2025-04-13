using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibraries.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentNo { get; set; }
        public string Admission { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string? MI { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string Nationality { get; set; }
        public string ContactNo { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string CivilStatus { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public string Parents_Guardian { get; set; }
        public string Relationship_to_Student { get; }
        public string Phone_Number { get; set; }

        public string School_Graduated { get; set; }
        public string Year_Graduated { get; set; }
        [Column(TypeName = "decimal(10, 2")]
        public decimal GWA { get; set; }


        //for transferee
        public string? Name_of_School { get; set; }
        public string? Last_Year_Level { get; set; }
        public string? Last_Year_Attended { get; set; }

        public string? Course_Strand { get; set; }

        public string School_Level { get; set; }
        public string Course_or_Strand { get; set; }
        public string Learners_Ref_No { get; set; }


        public ICollection<Payment> Payments { get; set; }
        
    }
}
