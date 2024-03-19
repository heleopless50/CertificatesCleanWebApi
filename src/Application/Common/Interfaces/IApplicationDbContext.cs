using clean_architecure_temp.Domain.Entities;
using SMSP.Database.MyTables;

namespace CleanWebApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Course> Courses { get; }
    DbSet<Department> Departments { get; }
    DbSet<Enrollment> Enrollments { get; }
    DbSet<Student> Students { get; }
    DbSet<StudyYear> StudyYears { get; }
    DbSet<Teacher> Teachers { get; }

    DbSet<Activity> Activities { get; }

    // public virtual DbSet<TeacherCourses> TeacherCourses { get; set; }
    DbSet<Exam> Exams { get; }
    DbSet<Result> Results { get; }
    DbSet<Certificate> Certificates { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
