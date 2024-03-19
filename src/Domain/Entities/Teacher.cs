using System.Xml.Serialization;

namespace SMSP.Database.MyTables;

public class Teacher
{

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public int DepartmentId { get; set; }

    [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DepartmentId))]
    public Department? Department { get; set; }

    public ICollection<Course>? Courses { get; set; }
}
