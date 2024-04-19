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
    ///
    /// </summary>
    public void Process_Item(bool bCanDoThis, string o2, float f, int y, string name, string FULLNAME)
    {
        // Get Some data
        var results = TestFixture.BuildEmployees();
        
        foreach (var result in results)
        {
            if(result.BirthdayDate.Year < 2000)
            {
                if (result.Position == "type1")
                {
                    // Assume we do something for this type of position
                }
                else 
                if (result.Position == "type2")
                {
                    // Assume we do somethingelse  for this type of position
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

    public void SaveToFile(string directoryPath, string fileName)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.WriteAllText(Path.Combine(directoryPath, fileName), ToString());
    }

    /// <summary>
    /// Get roles from AD or IAM
    /// </summary>
    /// <returns></returns>
    public string[] GetCurrentUserRoles() => new[]{"Admin"};



    public void LogError() { Console.WriteLine("Error"); }
    public void LogInformation(bool bCanDoThis, string o2, float f, int y, string name, string FULLNAME) { Console.WriteLine($"Info : {Guid.NewGuid()},{o2},{f},{y},{name}, {FULLNAME}"); }

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