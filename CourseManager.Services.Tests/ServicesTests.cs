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

      _translator.Setup(t => t.ToStudentTranslator(studentDto, null)).ReturnsAsync(student);

      //Act
      var successfull = await _services.InsertStudentAsync(studentDto);

      //Assert
      Assert.True(successfull);
      _translator.Verify(t => t.ToStudentTranslator(studentDto, null), Times.Once, "ToStudentTranslator should be called once");
      _commands.Verify(c => c.SaveChangesAsync(), Times.Once, "SaveChangesAsync should be called once");
    }
  }
}
