using SampleAPI.Controllers;
using SampleAPI.Features.CreateSampleObject;

namespace SampleAPI.ToRefactor;

/// <summary>
/// This class should be refactored to follow the SOLID principles and
/// Clean code principles
/// </summary>
public class MessyClass
{
    private PersonRepository _t;

    public MessyClass()
    {
        _t = new PersonRepository();
    }

    /// <summary>
    /// This method should write some financial data into a MySampleFinancial file
    /// and save the data into the Db via the Repo
    /// 
    /// If we are not allowed to do this, then throw exception
    /// </summary>
    /// <param name="bCanDoThis">some non objective param</param>
    /// <param name="personProfileType"></param>
    /// <param name="f">amount to pay</param>
    /// <param name="y">Year</param>
    /// <returns></returns>
    public async Task DoSomethingSpecial(bool bCanDoThis, string o2, float f, int y, string FULLNAME)
    {
        /if(UserAuthenticated)

        if (bCanDoThis)
        {
            File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial.csv", "id, profile_type, amount, year, fullname");


            var results = _t.Get();

            var list = new List<dynamic>();

            foreach (var result in results)
            {
                if (result.ProfileType == "type1")
                {
                    Console.WriteLine("Do something");
                }
                else
                if (result.ProfileType == "type2")
                {
                    Console.WriteLine("Do something else");
                }
                else
                {
                    throw new Exception("Unknown profile type");
                }
            }

            foreach (var o in list)
            {
                File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial.csv", $"{o.id},{o.personProfileType},{o.f},{o.y},{o.name}, {FULLNAME}");
            }
        }
        else
        {
            throw new Exception("Cannot do this");
        }
    }

    public IEnumerable<Employee> Get()
    {
        yield return new Employee
        {
            Amount = 123456,
            BirthdayDate = new DateTime(2014, 04, 10),
            Name = "CDM",
            ProfileType = "type1"
        };
    }
    
    // TODO > Maybe we'll need this method someday
    //public IEnumerable<Foo> Get(dynamic filter)
    //{
    //    var list = Get();
    //    return list.Where(x => x.Name.Contains(filter.Name));
    //}
}

public class PersonRepository
{
    public IEnumerable<Employee> Get(string name = null)
    {
        if(name is not null)
            yield return new Employee { ProfileType = "type1", Amount = 123f, BirthdayDate = new DateTime(1999, 1,1), Name = "Doe1" };
        else
        {
            yield return new Employee{ ProfileType = "type1", Amount = 123f, BirthdayDate = new DateTime(1999, 1, 1), Name = "Doe1" };
            yield return new Employee{ ProfileType = "type1", Amount = 124f, BirthdayDate = new DateTime(1995, 1, 1), Name = "Doe2" };
            yield return new Employee{ ProfileType = "type2", Amount = 125f, BirthdayDate = new DateTime(1998, 1, 1), Name = "Doe3" };
            yield return new Employee{ ProfileType = "type2", Amount = 126f, BirthdayDate = new DateTime(1999, 1, 1), Name = "Doe4" };
            yield return new Employee { ProfileType = "type2", Amount = 127f, BirthdayDate = new DateTime(1997, 1, 1), Name = "Doe5" };
        }
    }
}
