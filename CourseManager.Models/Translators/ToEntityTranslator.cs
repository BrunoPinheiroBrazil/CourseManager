using CourseManager.Models.Dtos;
using CourseManager.Models.Entities;
using System.Threading.Tasks;

namespace CourseManager.Models.Translators
{
  public interface IToEntityTranslator
  {
    Task<Student> ToStudentTranslator(StudentDto studentDto, Student student = null);
  }
  public class ToEntityTranslator : IToEntityTranslator
  {
    public async Task<Student> ToStudentTranslator(StudentDto studentDto, Student student = null)
    {
      if (student == null)
        return await Task.FromResult(new Student
        {
          FirstName = studentDto.FirstName,
          SurName = studentDto.SurName,
          Gender = studentDto.Gender,
          Dob = studentDto.Dob,
          Address1 = studentDto.Address1,
          Address2 = studentDto.Address2,
          Address3 = studentDto.Address3
        });

      student.FirstName = studentDto.FirstName;
      student.SurName = studentDto.SurName;
      student.Gender = studentDto.Gender;
      student.Dob = studentDto.Dob;
      student.Address1 = studentDto.Address1;
      student.Address2 = studentDto.Address2;
      student.Address3 = studentDto.Address3;

      return await Task.FromResult(student);
    }
  }
}
