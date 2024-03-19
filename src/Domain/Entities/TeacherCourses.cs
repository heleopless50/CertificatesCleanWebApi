/*namespace SMSP.Database.MyTables;

public class TeacherCourses
{
    public int CourseId { get; set; }
    [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CourseId))]
    public Course Course { get; set;}

    public int TeacherId { get; set;}
    [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TeacherId))]
    public Teacher Teacher { get; set; }
}
*/