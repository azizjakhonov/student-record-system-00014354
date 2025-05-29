// Student ID: 00014354
using System.ComponentModel.DataAnnotations;

namespace StudentRecordSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        public int Credits { get; set; }

        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
