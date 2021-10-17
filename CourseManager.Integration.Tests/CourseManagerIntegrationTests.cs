using CourseManager.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

    [Fact(DisplayName = "Insert Student [Success]")]
    public async Task Insert_Student_Success()
    {
      //Arrange
      var url = "coursemanager/create/student";
      var studentDto = new StudentDto
      {
        FirstName = "Jovem",
        SurName = "Juvenal",
        Address1 = "SomeAddress1",
        Address2 = "SomeAddress2",
        Address3 = "SomeAddress3",
        Dob = DateTime.Now,
        Gender = "M"
      };

      var studentDtoJson = JToken.FromObject(studentDto).ToString();

      var httpMessageContent = new StringContent(studentDtoJson, Encoding.UTF8, "application/json");

      //Act
      var response = await _client.PostAsync(url, httpMessageContent);

      //Assert
      Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
  }
}
