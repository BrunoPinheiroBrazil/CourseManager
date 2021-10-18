using CourseManager.Models.Entities;
using System;
using System.Threading.Tasks;

namespace CourseManager.DataBase.SqlServer.DataAccess
{
  public interface ICommands
  {
    Task SaveChangesAsync();
    Task AddStudentAsync(Student student);
  }
  public class Commands : ICommands
  {
    private readonly CourseManagerDbContext _context;

    public Commands(CourseManagerDbContext context)
    {
      _context = context;
    }

    public async Task AddStudentAsync(Student student)
    {
      await _context.AddAsync(student);
      await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}
