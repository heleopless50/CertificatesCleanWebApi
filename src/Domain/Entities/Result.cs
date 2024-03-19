namespace SMSP.Database.MyTables;

public class Result
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int ExamId { get; set; }
    public Exam? Exam { get; set; }
    public double Marks { get; set; }
}
