using System.ComponentModel.DataAnnotations;

namespace Assignment4.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string standard{ get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public List<Subject> sub { get; set; }
    }
}
