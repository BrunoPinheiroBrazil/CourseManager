using CourseManager.Common.Tests;
using CourseManager.Controllers;
using CourseManagerServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.Tests
{
  public class CourseManagerControllerTests
  {
    private readonly CourseManagerController _controller;
    private readonly Mock<IServices> _services;

    public CourseManagerControllerTests()
    {
      _services = new Mock<IServices>();
      _controller = new CourseManagerController(_services.Object);
    }

    [Fact(DisplayName = "Add Student [Success]")]
    public async Task InsertStudent_Success()
    {
      //Arrange
      var studentDto = CommonTestsFactory.CreateStudentDto("M", 4);

      _services.Setup(s => s.InsertStudentAsync(studentDto)).ReturnsAsync(5);

      //Act
      var response = await _controller.InsertStudent(studentDto);

      //Assert
      var responseStatus = Assert.IsType<OkObjectResult>(response);
      Assert.Equal(200, responseStatus.StatusCode);
      _services.Verify(s => s.InsertStudentAsync(studentDto), Times.Once, "InsertStudent should be called once");
    }

    [Fact(DisplayName = "UpdateStudent [Success]")]
    public async Task UpdateStudent_Success()
    {
      //Arrange
      var studentId = 3L;
      var studentDto = CommonTestsFactory.CreateStudentDto("F", 4);

      _services.Setup(s => s.UpdateStudentAsync(studentId, studentDto));

      //Act
      var response = await _controller.UpdateStudent(studentId, studentDto);

      //Assert
      var responseStatus = Assert.IsType<NoContentResult>(response);
      Assert.Equal(204, responseStatus.StatusCode);
      _services.Verify(s => s.UpdateStudentAsync(studentId, studentDto), Times.Once, "UpdateStudent should be called once");
    }

    [Fact(DisplayName = "Add Course [Success]")]
    public async Task InsertCourse_Success()
    {
      //Arrange
      var courseDto = CommonTestsFactory.CreateCourseDto();

      _services.Setup(s => s.InsertCourseAsync(courseDto)).ReturnsAsync(5);

      //Act
      var response = await _controller.InsertCourse(courseDto);

      //Assert
      var responseStatus = Assert.IsType<OkObjectResult>(response);
      Assert.Equal(200, responseStatus.StatusCode);
      _services.Verify(s => s.InsertCourseAsync(courseDto), Times.Once, "InsertCourse should be called once");
    }

    [Fact(DisplayName = "UpdateCourse [Success]")]
    public async Task UpdateCourse_Success()
    {
      //Arrange
      var courseId = 2L;
      var courseDto = CommonTestsFactory.CreateCourseDto();

      _services.Setup(s => s.UpdateCourseAsync(courseId, courseDto));

      //Act
      var response = await _controller.UpdateCourse(courseId, courseDto);

      //Assert
      var responseStatus = Assert.IsType<NoContentResult>(response);
      Assert.Equal(204, responseStatus.StatusCode);
      _services.Verify(s => s.UpdateCourseAsync(courseId, courseDto), Times.Once, "UpdateCourse should be called once");
    }
  }
}
