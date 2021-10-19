using CourseManager.Common.Tests;
using CourseManager.Models.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.Integration.Tests
{
  public class CourseManagerIntegrationTests : IClassFixture<CustomWebApplicationFactory<TestStartup>>
  {
    private readonly CustomWebApplicationFactory<TestStartup> _factory;
    private HttpClient _client;

    public CourseManagerIntegrationTests(CustomWebApplicationFactory<TestStartup> factory)
    {
      _factory = factory;
      _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
      {
        AllowAutoRedirect = false
      });
    }

    #region Student
    [Fact(DisplayName = "Insert Student [Success]")]
    public async Task Insert_Student_Success()
    {
      //Arrange
      var url = "coursemanager/create/student";
      var studentDto = CommonTestsFactory.CreateStudentDto("M", 4);

      var studentDtoJson = JToken.FromObject(studentDto).ToString();

      var httpMessageContent = new StringContent(studentDtoJson, Encoding.UTF8, "application/json");

      //Act
      var response = await _client.PostAsync(url, httpMessageContent);

      //Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact(DisplayName = "Update Student [Success]")]
    public async Task Update_Student_Success()
    {
      //Arrange
      var studentId = 1;
      var url = $"coursemanager/update/student/{studentId}";
      var studentDto = CommonTestsFactory.CreateStudentDto("F", 4);
      var studentDtoJson = JToken.FromObject(studentDto).ToString();

      var httpMessageContent = new StringContent(studentDtoJson, Encoding.UTF8, "application/json");

      //Act
      var response = await _client.PutAsync(url, httpMessageContent);

      //Assert
      Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact(DisplayName = "Update Student [Failure] - Student does not exists")]
    public async Task Update_Student_Failure_Student_Does_Not_Exists()
    {
      //Arrange
      var studentId = 4343;
      var url = $"coursemanager/update/student/{studentId}";
      var studentDto = CommonTestsFactory.CreateStudentDto("F", 4);

      var studentDtoJson = JToken.FromObject(studentDto).ToString();

      var httpMessageContent = new StringContent(studentDtoJson, Encoding.UTF8, "application/json");

      //Act
      //Assert
      _ = await Assert.ThrowsAsync<Exception>(() => _client.PutAsync(url, httpMessageContent));
    }
    #endregion

    #region Course
    [Fact(DisplayName = "Insert Course [Success]")]
    public async Task Insert_Course_Success()
    {
      //Arrange
      var url = "coursemanager/create/course";
      var courseDto = new CourseDto
      {
        CourseCode = "AB5ED",
        CourseName = "Magic",
        TeacherName = "Dumbledore",
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddMonths(1)
      };

      var courseDtoJson = JToken.FromObject(courseDto).ToString();

      var httpMessageContent = new StringContent(courseDtoJson, Encoding.UTF8, "application/json");

      //Act
      var response = await _client.PostAsync(url, httpMessageContent);

      //Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact(DisplayName = "Update Course [Success]")]
    public async Task Update_Course_Success()
    {
      //Arrange
      var courseId = 1;
      var url = $"coursemanager/update/course/{courseId}";
      var courseDto = CommonTestsFactory.CreateCourseDto();
      var courseDtoJson = JToken.FromObject(courseDto).ToString();

      var httpMessageContent = new StringContent(courseDtoJson, Encoding.UTF8, "application/json");

      //Act
      var response = await _client.PutAsync(url, httpMessageContent);

      //Assert
      Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact(DisplayName = "Update Course [Failure] - Course does not exists")]
    public async Task Update_Course_Failure_Student_Does_Not_Exists()
    {
      //Arrange
      var courseId = 434354;
      var url = $"coursemanager/update/course/{courseId}";
      var courseDto = CommonTestsFactory.CreateCourseDto();

      var courseDtoJson = JToken.FromObject(courseDto).ToString();

      var httpMessageContent = new StringContent(courseDtoJson, Encoding.UTF8, "application/json");

      //Act
      //Assert
      _ = await Assert.ThrowsAsync<Exception>(() => _client.PutAsync(url, httpMessageContent));
    }
    #endregion
  }
}
