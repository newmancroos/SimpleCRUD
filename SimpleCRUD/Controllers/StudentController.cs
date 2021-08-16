using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace SimpleCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _dbContext;
        public StudentController(StudentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("getallstudents")]
        public ActionResult GetAllStudents()
        {
            var students = _dbContext.Students.ToList();
            if (students == null)
            {
                return new ObjectResult(new ProblemDetail { Status = 404, Title = "Not Found", Description = "Student not found" })
                {
                    StatusCode = 404
                };
            }
            return Ok(students);
        }

        [HttpGet("getstudent/{studentId}")]
        public ActionResult GetStudent(int studentId)
        {
            try
            {
                var student = _dbContext.Students.Find(studentId);
                if (student == null)
                {
                    return new ObjectResult(new ProblemDetail { Status = 404, Title = "Not Found", Description = "Student not found" })
                    {
                        StatusCode = 404
                    };
                }
                return Ok(student);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("addstudent")]
        public ActionResult AddStudent(Student student)
        {
            try
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                return Ok(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("updatestudent")]
        public ActionResult UpdateStudent(Student student)
        {
            try
            {
                var std = _dbContext.Students.Find(student.Id);
                if (std == null)
                {
                    return new ObjectResult(new ProblemDetail { Status = 404, Title = "Not Found", Description = "Student not found" })
                    {
                        StatusCode = 404
                    };
                }
                _dbContext.Update(student);
                _dbContext.SaveChanges();
                return Ok(student);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("deletestudent/{studentId}")]
        public ActionResult DeleteStudent(int studentId)
        {
            try
            {
                var student = _dbContext.Students.Find(studentId);
                if (student == null)
                {
                    return new ObjectResult(new ProblemDetail { Status = 404, Title = "Not Found", Description = "Student not found" })
                    {
                        StatusCode = 404
                    };
                }
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
                return Ok($"Student with Id {studentId} has been deleted.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
