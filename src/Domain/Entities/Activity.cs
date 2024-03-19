namespace SMSP.Database.MyTables;

public class Activity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public bool? IsRequired { get; set; }

    public bool? IsFinished { get; set; }

    public string? ActivityFile { get; set; }

    public int CourseId { get;set; }
    [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CourseId))]
    public Course? Course { get; set;}

}
