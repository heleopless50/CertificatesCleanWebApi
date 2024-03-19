
using SMSP.Database.Enums;

namespace SMSP.Database.MyTables;

public class Exam
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string TypeCode { get; set; } = string.Empty;
    public string? Instructions { get; set; }

    public double MaximumMarks { get; set; }
    public TimeSpan Duration { get; set; }

    public ExamStatus Status { get; set; } 

    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();


}
