using System.Reflection;
using clean_architecure_temp.Domain.Entities;
using CleanWebApi.Application.Common.Interfaces;
using CleanWebApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSP.Database.MyTables;

namespace CleanWebApi.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public virtual DbSet<Course> Courses => Set<Course>();
    public virtual DbSet<Department> Departments => Set<Department>();
    public virtual DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public virtual DbSet<Student> Students => Set<Student>();
    public virtual DbSet<StudyYear> StudyYears => Set<StudyYear>();
    public virtual DbSet<Teacher> Teachers => Set<Teacher>();

    public virtual DbSet<Activity> Activities => Set<Activity>();

    // public virtual DbSet<TeacherCourses> TeacherCourses { get; set; }
    public virtual DbSet<Exam> Exams => Set<Exam>();
    public virtual DbSet<Result> Results => Set<Result>();
    public virtual DbSet<Certificate> Certificates => Set<Certificate>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
