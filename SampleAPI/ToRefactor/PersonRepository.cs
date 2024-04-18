using Microsoft.EntityFrameworkCore;
using SampleAPI.Controllers;
using SampleAPI.Features.CreatePerson;

namespace SampleAPI.ToRefactor;

public class PersonRepository
{
    private readonly PersonDbContext _dbContext;

    public PersonRepository(PersonDbContext context)
    {
        _dbContext = context;
    }
    
    public void Save()
    {
        _dbContext.SaveChanges();
    }
    
    public void SendEmail() { Console.WriteLine("Email Sent!!"); }

    public bool IsAuthenticated()
    {
        return true;
    }

    public void AddEmployee(Employee employee)
    {
        _dbContext.Employees.Add(employee);
    }
}