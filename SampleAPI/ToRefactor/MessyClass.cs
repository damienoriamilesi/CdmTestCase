using SampleAPI.Controllers;

namespace SampleAPI.ToRefactor;

/// <summary>
/// This class should be refactored to follow the SOLID principles and
/// Clean code principles
/// </summary>
public class MessyClass
{
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
    public Task Process(bool bCanDoThis, string o2, float f, int y, string FULLNAME)
    {
        if (UserAuthenticated)
        {
            // Get Some data
            var results = TestFixture.BuildEmployees();

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
                    var ex = new Exception("Unknown profile type");
                    File.WriteAllText(@"C:\something\Error.txt", ex.ToString());
                    throw ex;
                }
            }
            
            File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial.csv", "id, profile_type, amount, year, fullname");
            foreach (var o in list)
            {
                File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial.csv", $"{o.id},{o.personProfileType},{o.f},{o.y},{o.name}, {FULLNAME}");
            }
        }
        else
        {
            throw new Exception("Cannot do this");
        }

        return Task.CompletedTask;
    }

    public bool UserAuthenticated => true;
    
    // TODO > Maybe we'll need this method someday
    //public IEnumerable<Foo> Get(dynamic filter)
    //{
    //    var list = Get();
    //    return list.Where(x => x.Name.Contains(filter.Name));
    //}
}