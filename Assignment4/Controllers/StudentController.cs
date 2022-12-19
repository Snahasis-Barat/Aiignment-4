using Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Assignment4.Controllers
{
    [ApiController]
    [Route("api/Student")]
    public class StudentController : Controller
    {
      
        private readonly StudentDbContext _db;
        public StudentController(StudentDbContext db)
        {
            _db = db;
        }

        [Route("CreateStudent")]
        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student s)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.StudentTable.Add(s);
            _db.SaveChanges();

            return Ok(s);
        }

        
        
        [HttpGet("id")]
        public ActionResult<Student> GetStudentbyId(int id)
        {
            List<Student> student = _db.StudentTable.ToList();
            List<Student> student2 = new List<Student>();
            List<Subject> subject = _db.SubjectTable.ToList();
            int flag = 0;
           for (int i = 0; i < student.Count; i++)
            {
              
                if (student[i].StudentId == id)
                {
                    flag = 1;
                    student2.Add(student[i]);
                }
            }
           if(flag==0)
            {
                return BadRequest("Invalid Student Id");
            }
            return Ok(student2);
           
        }

        [HttpGet]
        public ActionResult<Student> GetAllStudents()
        {
            List<Student> student = _db.StudentTable.ToList();
            List<Subject> subject = _db.SubjectTable.ToList();
           
           if(student.Count==0)
            {
                return BadRequest("No records available");
            }
           
            return Ok(st);

        }

        [HttpDelete]
        public ActionResult<Student> DeleteStudent(int id)
        {
            List<Student> student1 = _db.StudentTable.ToList();
            List<Student> student2 = new List<Student>();
            List<Subject> subject = _db.SubjectTable.ToList();
            var s = _db.StudentTable.FirstOrDefault(x => x.StudentId == id);
            if(s==null)
            {
                return BadRequest("Invalid student id");
            }
            _db.StudentTable.Remove(s);
            _db.SaveChanges();
            return Ok(s);
        }

        [HttpPut]
        public ActionResult<Student> UpdateStudent(int id, [FromBody] Student s)
        {
            int flag = 0;
            List<Student> student = _db.StudentTable.ToList();
            List<Subject> subject = _db.SubjectTable.ToList();
            if (s == null)
            {
                return BadRequest("Empty student details");
            }
            else
            {
                for (int i = 0; i < student.Count(); i++)
                {
                    if (student[i].StudentId == id)
                    {
                        flag = 1;
                        student[i].name = s.name;
                        student[i].age = s.age;
                        student[i].standard = s.standard;
                        student[i].sub = s.sub;
                        _db.SaveChanges();
                    }
                }
            }
            if (flag == 0)
            {
                return BadRequest("Invalid student id");
            }
            return Ok(student);

        }

    }
}
