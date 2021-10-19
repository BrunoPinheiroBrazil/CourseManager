using CourseManager.Models.Dtos;
using CourseManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Models.Translators
{
  public interface IToDtoTranslator
  {
    Task<StudentDto> ToStudentDto(Student student);
  }
  public class ToDtoTranslator : IToDtoTranslator
  {
    public async Task<StudentDto> ToStudentDto(Student student)
    {
      return await Task.FromResult(new StudentDto
      {
        FirstName = student.FirstName,
        SurName = student.SurName,
        Gender = student.Gender,
        Dob = student.Dob,
        Address1 = student.Address1,
        Address2 = student.Address2,
        Address3 = student.Address3,
        StudentId = student.StudentId
      });
    }
  }
}
