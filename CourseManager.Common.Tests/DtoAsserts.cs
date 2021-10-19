using CourseManager.Models.Dtos;
using CourseManager.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.Common.Tests
{
  public static class DtoAsserts
  {
    public async static Task AssertStudentDto(Student expectedStudent, StudentDto currentStudentDto)
    {
      var tasks = new List<Task>();

      tasks.AddRange(new List<Task>
      {
        Task.Run(() =>
        {
          Assert.Equal(expectedStudent.FirstName, currentStudentDto.FirstName);
        }),
        Task.Run(() =>
        {
          Assert.Equal(expectedStudent.SurName, currentStudentDto.SurName);
        }),
        Task.Run(() =>
        {
          Assert.Equal(expectedStudent.Dob, currentStudentDto.Dob);
        }),
        Task.Run(() =>
        {
          Assert.Equal(expectedStudent.Gender, currentStudentDto.Gender);
        }),
        Task.Run(() =>
        {
          Assert.Equal(expectedStudent.Address1, currentStudentDto.Address1);
        }),
        Task.Run(() =>
        {
          Assert.Equal(expectedStudent.Address2, currentStudentDto.Address2);
        }),
        Task.Run(() =>
        {
          Assert.Equal(expectedStudent.Address3, currentStudentDto.Address3);
        }),
      });   
      Task t = Task.WhenAll(tasks);

      await t;
    }
  }
}
