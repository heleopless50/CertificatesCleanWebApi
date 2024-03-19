using System.ComponentModel.DataAnnotations;

namespace SMSP.Database.MyTables
{



    public class Enrollment
    {

        //public int Id { get; set; }

        public int StudentId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }
   
        public int CourseId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public int? Grade { get; set; }

        public int? Degrees { get; set; } = 0;

        public bool? IsFinished { get; set; }

        public Guid CompositeKey { get; set; }
    }

}
