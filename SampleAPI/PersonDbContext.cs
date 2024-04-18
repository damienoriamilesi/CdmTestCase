using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Controllers;
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
        yield return new Employee{ ProfileType = "type1", Amount = 123f, BirthdayDate = new DateTime(1999, 1, 1), Name = "Doe1" };
        yield return new Employee{ ProfileType = "type1", Amount = 124f, BirthdayDate = new DateTime(1995, 1, 1), Name = "Doe2" };
        yield return new Employee{ ProfileType = "type2", Amount = 125f, BirthdayDate = new DateTime(1998, 1, 1), Name = "Doe3" };
        yield return new Employee{ ProfileType = "type2", Amount = 126f, BirthdayDate = new DateTime(1999, 1, 1), Name = "Doe4" };
        yield return new Employee{ ProfileType = "type2", Amount = 127f, BirthdayDate = new DateTime(1997, 1, 1), Name = "Doe5" };
    }
}