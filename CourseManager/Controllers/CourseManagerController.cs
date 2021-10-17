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
      if (await _services.InsertStudentAsync(studentDto))
        return await Task.FromResult(NoContent());

      throw new Exception("An error ocurred during the creation of the student!");
    }
  }
}
