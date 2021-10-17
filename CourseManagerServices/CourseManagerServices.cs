using CourseManager.DataBase.SqlServer.DataAccess;
using CourseManager.Models.Dtos;
using CourseManager.Models.Translators;
using System.Threading.Tasks;

namespace CourseManagerServices
{
  public interface IServices
  {
    Task<bool> InsertStudentAsync(StudentDto studentDto);
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

    public async Task<bool> InsertStudentAsync(StudentDto studentDto)
    {
      var student = await _toEntityTranslator.ToStudentTranslator(studentDto);

      await _commands.SaveChangesAsync();
      return true;
    }
  }
}
