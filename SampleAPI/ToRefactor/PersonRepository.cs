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

    public void AddEmployee(Employee employee)
    {
        _dbContext.Employees.Add(employee);
    }

    public Employee[] Get(Guid? id = null)
    {
        var employees = _dbContext.Employees;
        if (!id.HasValue) return employees.ToArray();
        return employees.Where(x => x.Id == id).ToArray();
    }
}