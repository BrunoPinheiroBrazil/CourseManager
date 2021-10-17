using System;
using System.Threading.Tasks;

namespace CourseManager.DataBase.SqlServer.DataAccess
{
  public interface ICommands
  {
    Task SaveChangesAsync();
  }
  public class Commands : ICommands
  {
    public async Task SaveChangesAsync()
    {
      throw new NotImplementedException();
    }
  }
}
