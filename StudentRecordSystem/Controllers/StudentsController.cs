// Student ID: 00014354
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRecordSystem.Data;
using StudentRecordSystem.Models;
using StudentRecordSystem.Models.Dtos;

namespace StudentRecordSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IGenericRepository<Student> _repo;

        public StudentsController(IGenericRepository<Student> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] ApplicationDbContext context)
        {
            var studentsWithCourses = await context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .ToListAsync();

            return Ok(studentsWithCourses);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            await _repo.AddAsync(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Student updated)
        {
            if (id != updated.Id) return BadRequest();
            await _repo.UpdateAsync(updated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{studentId}/Courses")]
        public async Task<IActionResult> AssignCourseToStudent(int studentId, [FromBody] CourseAssignmentDto dto)
        {
            var student = await _repo.GetByIdAsync(studentId);
            if (student == null) return NotFound("Student not found");

            if (student.StudentCourses == null)
                student.StudentCourses = new List<StudentCourse>();

            // Prevent duplicates
            if (student.StudentCourses.Any(sc => sc.CourseId == dto.CourseId))
                return BadRequest("Course already assigned");

            student.StudentCourses.Add(new StudentCourse
            {
                StudentId = studentId,
                CourseId = dto.CourseId
            });

            await _repo.UpdateAsync(student);
            return Ok();
        }
    }
}
