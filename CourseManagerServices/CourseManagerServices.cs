using CourseManager.DataBase.SqlServer.DataAccess;
using CourseManager.Models.Dtos;
using CourseManager.Models.Translators;
using System.Threading.Tasks;

namespace CourseManagerServices
{
  public interface IServices
  {
    Task<bool> InsertStudentAsync(StudentDto studentDto);
    Task<bool> InsertCourseAsync(CourseDto courseDto);
  }
  public class Services : IServices
  {
    private readonly IToEntityTranslator _toEntityTranslator;
    private readonly ICommands _commands;
    public Services(IToEntityTranslator translator, ICommands commands)
    {
      _toEntityTranslator = translator;
      _commands = commands;
    }

    public async Task<bool> InsertCourseAsync(CourseDto courseDto)
    {
      var course = await _toEntityTranslator.ToCourse(courseDto);

      await _commands.AddCourseAsync(course);
      return true;
    }

    public async Task<bool> InsertStudentAsync(StudentDto studentDto)
    {
      var student = await _toEntityTranslator.ToStudent(studentDto);

      await _commands.AddStudentAsync(student);
      return true;
    }
  }
}
