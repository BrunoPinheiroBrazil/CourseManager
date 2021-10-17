using CourseManager.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.Integration.Tests
{
  public class CourseManagerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
  {
    private readonly CustomWebApplicationFactory<Startup> _factory;
    private HttpClient _client;

    public CourseManagerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
    {
      _factory = factory;
      _client = _factory.CreateClient();
    }

    [Fact(DisplayName = "Insert Student [Success]")]
    public async Task Insert_Student_Success()
    {
      //Arrange
      var url = "create/client";
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

      var httpMessage = new HttpRequestMessage
      {
        Content = new StringContent(studentDtoJson)
      };

      //Act
      var response = await _client.PostAsync(url, httpMessage.Content);

      //Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
  }
}
