
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SMSP.Database.MyTables
{


public class Student
{
        [Key]
    public int Id { get; set; }
    public string? Name { get; set; }

    public DateTime DateOfBirth { get; set; }
    public char Gender { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime? GraduationDate { get; set; }
    public string? Status { get; set; }
    public string? Photo { get; set; } 
    public required string NationalID { get; set; }
    public bool IsActive { get; set; }

    public int StudyYearId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StudyYearId))]
        public StudyYear? StudyYear { get; set; }

    public int DepartmentId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}

}
