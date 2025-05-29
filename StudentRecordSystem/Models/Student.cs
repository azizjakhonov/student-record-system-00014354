// Student ID: 00014354
using System.ComponentModel.DataAnnotations;

namespace StudentRecordSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
