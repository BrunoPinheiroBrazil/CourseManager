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

    [Fact(DisplayName = "AddStudentAsync [Success]")]
    public async Task AddStudentAsync_Success()
    {
      //Arrange
      var student = CommonTestsFactory.CreateStudent("M", 4);

      //Act
      await _commands.AddStudentAsync(student);

      //Assert
      var currentStudent = _fixture.Context.Students.FirstOrDefault(s => s.FirstName == student.FirstName);
      Assert.NotNull(currentStudent);
      Assert.Equal(student.Address1, currentStudent.Address1);
      Assert.Equal(student.Address2, currentStudent.Address2);
      Assert.Equal(student.Address3, currentStudent.Address3);
    }
    [Fact(DisplayName = "AddCourseAsync [Success]")]
    public async Task AddCourseAsync_Success()
    {
      //Arrange
      var course = CommonTestsFactory.CreateCourse();

      //Act
      await _commands.AddCourseAsync(course);

      //Assert
      var currentCourse = _fixture.Context.Courses.FirstOrDefault(c => c.CourseCode == course.CourseCode);
      Assert.NotNull(currentCourse);
      Assert.Equal(course.CourseCode, currentCourse.CourseCode);
      Assert.Equal(course.CourseName, currentCourse.CourseName);
      Assert.Equal(course.TeacherName, currentCourse.TeacherName);
      Assert.Equal(course.StartDate, currentCourse.StartDate);
      Assert.Equal(course.EndDate, currentCourse.EndDate);
    }
  }
}
