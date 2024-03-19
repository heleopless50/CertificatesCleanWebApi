namespace SMSP.Database.MyTables
{


    public class StudyYear
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int YearNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
