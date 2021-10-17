using CourseManager.Controllers;
using CourseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.Tests
{
  public class CourseManagerControllerTests
  {
    private readonly CourseManagerController _controller;
    public CourseManagerControllerTests()
    {
      _controller = new CourseManagerController();
    }

    [Fact(DisplayName = "Add Student [Success]")]
    public async Task AddStudent_Success()
    {
      //Arrange
      var student = new StudentDto
      {
        FirstName = "SomeFirstName",
        SurName = "SomeSurName",
        Gender = "SomeGender",
        Dob = DateTime.Now,
        Address1 = "SomeAddress1",
        Address2 = "SomeAddress2",
        Address3 = "SomeAddress3"
      };

      //Act
      var response = await _controller.InsertStudent(student);

      //Assert
      var responseStatus = Assert.IsType<NoContentResult>(response);
      Assert.Equal(204, responseStatus.StatusCode);
    }
  }
}
