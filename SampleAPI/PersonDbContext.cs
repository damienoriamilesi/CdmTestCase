using Microsoft.EntityFrameworkCore;
using SampleAPI.Features.CreatePerson;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
}

internal static class TestFixture
{
    public static IEnumerable<Employee> BuildEmployees()
    {
        yield return new Employee{ Position = "position2", EmployeeNumber = 121f, BirthdayDate = new DateTime(2001, 1, 1), Name = "Doe5" };
        yield return new Employee{ Position = "position2", EmployeeNumber = 122f, BirthdayDate = new DateTime(2000, 1, 1), Name = "Doe5" };
        yield return new Employee{ Position = "position1", EmployeeNumber = 123f, BirthdayDate = new DateTime(1999, 1, 1), Name = "Doe1" };
        yield return new Employee{ Position = "position1", EmployeeNumber = 124f, BirthdayDate = new DateTime(1995, 1, 1), Name = "Doe2" };
        yield return new Employee{ Position = "position2", EmployeeNumber = 125f, BirthdayDate = new DateTime(1998, 1, 1), Name = "Doe3" };
        yield return new Employee{ Position = "position2", EmployeeNumber = 126f, BirthdayDate = new DateTime(1999, 1, 1), Name = "Doe4" };
        yield return new Employee{ Position = "position2", EmployeeNumber = 127f, BirthdayDate = new DateTime(1997, 1, 1), Name = "Doe5" };
    }
}