using CourseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseManager.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CourseManagerController : ControllerBase
  {
    [HttpPost("create/student")]
    public async Task<IActionResult> InsertStudent([FromBody] StudentDto student)
    {
      return await Task.FromResult(NoContent());
    }
  }
}
