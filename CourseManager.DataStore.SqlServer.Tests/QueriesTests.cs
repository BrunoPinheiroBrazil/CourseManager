using CourseManager.Common.Tests;
using CourseManager.DataBase.SqlServer.DataAccess;
using System.Threading.Tasks;
using Xunit;

namespace CourseManager.DataStore.SqlServer.Tests
{
  public class QueriesTests : IClassFixture<CourseManagerContextFixture>
  {
    private readonly CourseManagerContextFixture _fixture;
    private readonly IQueries _queries;

    public QueriesTests()
    {
      _fixture = new CourseManagerContextFixture();
      _queries = new Queries(_fixture.Context);
    }

    [Fact(DisplayName = "GetStudent [Success]")]
    public async Task GetStudent_Success()
    {
      //Arrange
      var student = CommonTestsFactory.CreateStudent("M", 4);

      await _fixture.Context.AddAsync(student);
      await _fixture.Context.SaveChangesAsync();

      var studentId = student.StudentId;

      //Act
      var currentStudent = await _queries.GetStudent(studentId);

      //Assert
      Assert.NotNull(currentStudent);
      Assert.Equal(student.FirstName, currentStudent.FirstName);
      Assert.Equal(student.SurName, currentStudent.SurName);
      Assert.Equal(student.Gender, currentStudent.Gender);
      Assert.Equal(student.Address1, currentStudent.Address1);
      Assert.Equal(student.Address2, currentStudent.Address2);
      Assert.Equal(student.Address3, currentStudent.Address3);
      Assert.Equal(student.Dob, currentStudent.Dob);
    }

    [Fact(DisplayName = "GetCourse [Success]")]
    public async Task GetCourse_Success()
    {
      //Arrange
      var course = CommonTestsFactory.CreateCourse();

      await _fixture.Context.AddAsync(course);
      await _fixture.Context.SaveChangesAsync();

      var courseId = course.CourseId;

      //Act
      var currentCourse = await _queries.GetCourse(courseId);

      //Assert
      Assert.NotNull(currentCourse);
      Assert.Equal(course.CourseCode, currentCourse.CourseCode);
      Assert.Equal(course.CourseName, currentCourse.CourseName);
      Assert.Equal(course.TeacherName, currentCourse.TeacherName);
      Assert.Equal(course.StartDate, currentCourse.StartDate);
      Assert.Equal(course.EndDate, currentCourse.EndDate);
    }
  }
}
