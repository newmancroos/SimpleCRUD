using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Student Name is Required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Address1 Name is Required")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
