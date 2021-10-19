using CourseManager.DataBase.SqlServer.DataAccess;
using CourseManager.Models.Dtos;
using CourseManager.Models.Translators;
using System;
using System.Threading.Tasks;

namespace CourseManagerServices
{
  public interface IServices
  {
    Task<long> InsertStudentAsync(StudentDto studentDto);
    Task<long> InsertCourseAsync(CourseDto courseDto);
    Task UpdateStudentAsync(long studentId, StudentDto studentDto);
    Task UpdateCourseAsync(long courseId, CourseDto courseDto);
  }
  public class Services : IServices
  {
    private readonly IToEntityTranslator _toEntityTranslator;
    private readonly IQueries _queries;
    private readonly ICommands _commands;
    public Services(IToEntityTranslator translator, ICommands commands, IQueries queries)
    {
      _toEntityTranslator = translator;
      _queries = queries;
      _commands = commands;
    }

    public async Task<long> InsertCourseAsync(CourseDto courseDto)
    {
      var course = await _toEntityTranslator.ToCourse(courseDto);

      return await _commands.AddCourseAsync(course);
    }

    public async Task<long> InsertStudentAsync(StudentDto studentDto)
    {
      var student = await _toEntityTranslator.ToStudent(studentDto);

      return await _commands.AddStudentAsync(student);
    }

    public async Task UpdateCourseAsync(long courseId, CourseDto courseDto)
    {
      var course = await _queries.GetCourse(courseId);

      if(course == null)
        throw new Exception("Course does not exists!");

      await _toEntityTranslator.ToCourse(courseDto, course);
      await _commands.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(long studentId, StudentDto studentDto)
    {
      var student = await _queries.GetStudent(studentId);

      if (student == null)
        throw new Exception("Student does not exists!");

      await _toEntityTranslator.ToStudent(studentDto, student);
      await _commands.SaveChangesAsync();
    }
  }
}
