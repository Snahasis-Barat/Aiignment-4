using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string SubjectName { get; set; }
        [Required]
        public int MarksObtained { get; set; }
        [Required]
        public int MaxMarks { get; set; }

        

        [Required]
        public int StudentId { get; set; }
    }

}