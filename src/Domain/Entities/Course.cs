namespace SMSP.Database.MyTables
{


    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int Credits { get; set; }
        
        public int? DepartmentId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; } = null;


        public int? StudyYearId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StudyYearId))]
        public StudyYear? StudyYear { get; set; } = null;

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();


    }
}
