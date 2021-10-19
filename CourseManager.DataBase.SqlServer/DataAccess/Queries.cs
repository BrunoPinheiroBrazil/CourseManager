using CourseManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.DataBase.SqlServer.DataAccess
{
  public interface IQueries
  {
    Task<Student> GetStudent(long studentId);
    Task<Course> GetCourse(long courseId);
  }
  public class Queries : IQueries
  {
    private readonly CourseManagerDbContext _context;

    public Queries(CourseManagerDbContext context)
    {
      _context = context;
    }

    public async Task<Course> GetCourse(long courseId)
    {
      return await CourseWithIncludes().FirstOrDefaultAsync(c => c.CourseId == courseId);
    }

    public async Task<Student> GetStudent(long studentId)
    {
      return await StudentWithIncludes().FirstOrDefaultAsync(s => s.StudentId == studentId);
    }

    private IQueryable<Student> StudentWithIncludes()
    {
      return _context.Students
        .Where(s => s.FirstName != null && s.SurName != null)
        .AsQueryable();
    }

    private IQueryable<Course> CourseWithIncludes()
    {
      return _context.Courses
        .Where(s => s.CourseCode != null)
        .AsQueryable();
    }
  }
}
