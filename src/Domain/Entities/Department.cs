namespace SMSP.Database.MyTables
{



    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
