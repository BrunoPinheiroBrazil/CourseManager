using CourseManager.Models.Dtos;
using CourseManagerServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseManager.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CourseManagerController : ControllerBase
  {
    private readonly IServices _services;
    public CourseManagerController(IServices services)
    {
      _services = services;
    }

    [HttpPost("create/student")]
    public async Task<IActionResult> InsertStudent([FromBody] StudentDto studentDto)
    {
      return Ok(await _services.InsertStudentAsync(studentDto));
    }

    [HttpPut("update/student/{studentId}")]
    public async Task<IActionResult> UpdateStudent(long studentId, [FromBody] StudentDto studentDto)
    {
      await _services.UpdateStudentAsync(studentId, studentDto);
      return NoContent();
    }

    [HttpPost("create/course")]
    public async Task<IActionResult> InsertCourse([FromBody] CourseDto courseDto)
    {
      return Ok(await _services.InsertCourseAsync(courseDto));
    }

    [HttpPut("update/course/{courseId}")]
    public async Task<IActionResult> UpdateCourse(long courseId, [FromBody] CourseDto courseDto)
    {
      await _services.UpdateCourseAsync(courseId, courseDto);
      return NoContent();
    }

    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetStudent(long studentId)
    {
      return Ok(await _services.GetStudent(studentId));
    }

    [HttpDelete("delete/student/{studentId}")]
    public async Task<IActionResult> DeleteStudent(long studentId)
    {
      await _services.DeleteStudentAsync(studentId);
      return NoContent();
    }
  }
}
