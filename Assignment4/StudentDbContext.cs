using Assignment4.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {
            
        }
        public DbSet<Student> StudentTable { get; set; }
        public DbSet<Subject> SubjectTable { get; set; }    
    }
}
