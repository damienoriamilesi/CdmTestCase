using SampleAPI.Features.CreatePerson;

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
    public void Save_Item(bool bCanDoThis, string o2, float f, int y, string name, string FULLNAME)
    {
        // Get Some data
        var results = TestFixture.BuildEmployees();
        
        foreach (var result in results)
        {
            if(result.BirthdayDate.Year < 2000)
            {
                if (result.ProfileType == "type1")
                {
                    var o = result;
                    File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial_1.csv", $"{Guid.NewGuid()},{o2},{f},{y},{name}, {FULLNAME}");
                }
                else 
                if (result.ProfileType == "type2")
                {
                    File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial_2.csv", $"{Guid.NewGuid()},{o2},{f},{y},, {FULLNAME}");
                }
                else
                {
                    var ex = new Exception("Unknown profile type");
                    File.WriteAllText(@"C:\something\Error.txt", ex.ToString());
                    throw ex;
                }
            }
        }
    }

    public string GetCurrentUser() => "CDM\\JohnDoe";

    public void LogError() { Console.WriteLine("Error"); }

    public void SendEmail()
    {
        File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial.csv", "id, profile_type, amount, year, fullname");
        //Send
    }

    // TODO > Maybe we'll need this method someday
    //public IEnumerable<Foo> Get(dynamic filter)
    //{
    //    var list = Get();
    //    return list.Where(x => x.Name.Contains(filter.Name));
    //}
}