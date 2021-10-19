using CourseManager.Common.Tests;
using CourseManager.DataBase.SqlServer.DataAccess;
using CourseManager.Models.Translators;
using CourseManagerServices;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CourseManagerServicesTests
{
  public class ServicesTests
  {
    private readonly Services _services;
    private readonly Mock<ICommands> _commands;
    private readonly Mock<IToEntityTranslator> _translator;

    public ServicesTests()
    {
      _translator = new Mock<IToEntityTranslator>();
      _commands = new Mock<ICommands>();
      _services = new Services(_translator.Object, _commands.Object);
    }

    [Fact(DisplayName = "InsertStudent [Success]")]
    public async Task InsertStudent_Success()
    {
      //Arrange
      var studentDto = CommonTestsFactory.CreateStudentDto("M", 4);
      var student = CommonTestsFactory.CreateStudent(null, 0, studentDto);

      _translator.Setup(t => t.ToStudent(studentDto, null)).ReturnsAsync(student);

      //Act
      var successfull = await _services.InsertStudentAsync(studentDto);

      //Assert
      Assert.True(successfull);
      _translator.Verify(t => t.ToStudent(studentDto, null), Times.Once, "ToStudentTranslator should be called once");
      _commands.Verify(c => c.AddStudentAsync(student), Times.Once, "AddStudentAsync should be called once");
    }

    [Fact(DisplayName = "InsertCourse [Success]")]
    public async Task InsertCourse_Success()
    {
      //Arrange
      var courseDto = CommonTestsFactory.CreateCourseDto();
      var course = CommonTestsFactory.CreateCourse(courseDto);

      _translator.Setup(t => t.ToCourse(courseDto, null)).ReturnsAsync(course);

      //Act
      var successfull = await _services.InsertCourseAsync(courseDto);

      //Assert
      Assert.True(successfull);
      _translator.Verify(t => t.ToCourse(courseDto, null), Times.Once, "ToCourseTranslator should be called once");
      _commands.Verify(c => c.AddCourseAsync(course), Times.Once, "AddCourseAsync should be called once");
    }
  }
}
