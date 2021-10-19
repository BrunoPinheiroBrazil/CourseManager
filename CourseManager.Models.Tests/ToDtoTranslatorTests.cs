using CourseManager.Common.Tests;
using CourseManager.Models.Translators;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.Models.Tests
{
  public class ToDtoTranslatorTests
  {
    private readonly ToDtoTranslator _toDtoTranslator;

    public ToDtoTranslatorTests()
    {
      _toDtoTranslator = new ToDtoTranslator();
    }

    [Fact(DisplayName ="ToStudentDto [Success]")]
    public async Task ToStudentDto_Success()
    {
      //Arrange
      var student = CommonTestsFactory.CreateStudent("F", 4);

      //Act
      var studentDto = await _toDtoTranslator.ToStudentDto(student);

      //Assert
      await DtoAsserts.AssertStudentDto(student, studentDto);
    }
  }
}
