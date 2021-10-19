using CourseManager.Common.Tests;
using CourseManager.Models.Translators;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.Models.Tests
{
  public class ToEntityTranslatorTests
  {
    private readonly ToEntityTranslator _translator;
    public ToEntityTranslatorTests()
    {
      _translator = new ToEntityTranslator();
    }

    [Fact(DisplayName ="ToStudent [Success]")]
    public async Task ToStudent_Success()
    {
      //Arrange
      var studentDto = CommonTestsFactory.CreateStudentDto("M", 5);

      //Act
      var student = await _translator.ToStudentTranslator(studentDto);

      //Assert
      Assert.Equal(studentDto.FirstName, student.FirstName);
      Assert.Equal(studentDto.SurName, student.SurName);
      Assert.Equal(studentDto.Dob, student.Dob);
      Assert.Equal(studentDto.Gender, student.Gender);
      Assert.Equal(studentDto.Address1, student.Address1);
      Assert.Equal(studentDto.Address2, student.Address2);
      Assert.Equal(studentDto.Address3, student.Address3);
    }

    [Fact(DisplayName = "ToCourse [Success]")]
    public async Task ToCourse_Success()
    {
      //Arrange
      var courseDto = CommonTestsFactory.CreateCourseDto();

      //Act
      var course = await _translator.ToCourseTranslator(courseDto);

      //Assert
      Assert.Equal(courseDto.CourseCode, course.CourseCode);
      Assert.Equal(courseDto.CourseName, course.CourseName);
      Assert.Equal(courseDto.TeacherName, course.TeacherName);
      Assert.Equal(courseDto.StartDate, course.StartDate);
      Assert.Equal(courseDto.EndDate, course.EndDate);
    }
  }
}
