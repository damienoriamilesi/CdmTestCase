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
    public async Task Process_Item(bool bCanDoThis, string o2, float f, int y, string name, string FULLNAME)
    {
        // TODO > nested IF?
        // TODO > 2000 => Variable
        // TODO > 
        // Get Some data
        var employees = TestFixture.BuildEmployees();


        foreach (var employee in employees)
        {
            var result = employee.GetSalary();
        }
    }

    public void SaveToFile(string directoryPath, string fileName)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // TODO > Check filename : not empty, has an extension
        File.WriteAllText(Path.Combine(directoryPath, fileName), "42".ToString());
    }

    /// <summary>
    /// Get roles from AD or IAM
    /// </summary>
    /// <returns></returns>
    // TODO > Replace "Admin" -> Add to settings / add to Constant
    // TODO > Add to Auth class
    public string[] GetCurrentUserRoles() => new[] { "Admin" };


    // TODO > add ex.Message
    public void LogError(Exception ex)
    {
        Console.WriteLine("Error occured: " + ex.Message);
        //throw; 
    }

    // TODO > Too many params / Params don't have any sense
    // TODO > What are we supposed to log? => 
    public void LogInformation(bool canDoThis, string city, float taxAmount, int cardNumber, string firstName, string fullname)
    {
        //Console.WriteLine($"Info : {Guid.NewGuid()},{o2},{f},{y},{name}, {fullname}");
    }

    public void SendEmail()
    {
        File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial.csv", "id, profile_type, amount, year, fullname");
        //Send
    }
}