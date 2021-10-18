using CourseManager.Common.Tests;
using CourseManager.DataBase.SqlServer;
using CourseManager.DataBase.SqlServer.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.DataStore.SqlServer.Tests
{
  public class CourseManagerContextFixture : IDisposable
  {
    public CourseManagerDbContext Context { get; private set; }

    public CourseManagerContextFixture()
    {
      var options = new DbContextOptionsBuilder<CourseManagerDbContext>()
            .UseInMemoryDatabase("CourseManagerCommandsTestDb")
            .Options;

      Context = new CourseManagerDbContext(options);

      Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
      Context.Dispose();
    }
  }
  public class CommandsTests : IClassFixture<CourseManagerContextFixture>
  {
    private readonly CourseManagerContextFixture _fixture;
    private readonly ICommands _commands;

    public CommandsTests()
    {
      _fixture = new CourseManagerContextFixture();
      _commands = new Commands(_fixture.Context);
    }

    [Fact(DisplayName = "SaveChangesAsync [Success]")]
    public async Task SaveChangesAsync_Success()
    {
      //Arrange
      var student = CommonTestsFactory.CreateStudent("M", 4);

      //Act
      await _commands.AddStudentAsync(student);

      //Assert
      var currentStudent = _fixture.Context.Students.FirstOrDefault(s => s.FirstName == student.FirstName);
      Assert.NotNull(currentStudent);
    }
  }
}
