using CourseManager.DataBase.SqlServer;
using CourseManager.Models.Entities;
using System.Collections.Generic;

namespace CourseManager.Integration.Tests
{
  public static class Utilities
  {
    public static void InitializeDbForTests(CourseManagerDbContext db)
    {
      db.Students.AddRange(GetStudentsList());
      db.SaveChanges();
    }

    public static void ReinitializeDbForTests(CourseManagerDbContext db)
    {
      db.Students.RemoveRange(db.Students);
      InitializeDbForTests(db);
    }

    public static List<Student> GetStudentsList()
    {
      return new List<Student>()
    {
        new Student(){ FirstName = "Mr Rock and Roll" },
        new Student(){ FirstName = "Mrs Lady Gaga" },
        new Student(){ FirstName = "Mr Anderson" }
    };
    }
  }
}
