// Student ID: 00014354
using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Data;
using StudentRecordSystem.Models;

namespace StudentRecordSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IGenericRepository<Course> _repo;

        public CoursesController(IGenericRepository<Course> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Course course)
        {
            await _repo.AddAsync(course);
            return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Course updated)
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
    }
}
