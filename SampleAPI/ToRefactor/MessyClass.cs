namespace SampleAPI.ToRefactor;

public class MessyClass
{
    private TotoData _t;

    public MessyClass()
    {
        _t = new TotoData();
    }

    /// <summary>
    /// This method should write some financial data into a file named MySampleFinancial
    /// and save the data into the Db via the Repo
    /// 
    /// If we are not allowed to do this, then throw exception
    /// </summary>
    /// <param name="bCanDoThis">some non objective param</param>
    /// <param name="personProfileType"></param>
    /// <param name="f">amount to pay</param>
    /// <param name="y">Year</param>
    /// <returns></returns>
    public async Task DoSomethingSpecial(bool bCanDoThis, string personProfileType, float f, int y, string FULLNAME)
    {
        if (bCanDoThis)
        {
            File.AppendAllTextAsync(@"C:\tempMessyClassTest\MySampleFinancial.txt", "id, profile_type, amount, year, fullname");

            var results = _t.AccessDataSample();

            // TODO > replace with SampleDto
            var list = new List<dynamic>();

            foreach (var result in results)
            {
                if (result.personProfileType == personProfileType)
                {
                    list.Add(result);
                }
                else
                {
                    if(list.Any(x => x.f == f && x.y == y && x.name == FULLNAME))
                        list.Add(result);
                    else
                        throw new Exception("cannot add to the file");
                }
            }

            foreach (dynamic o in list)
            {
                File.AppendAllTextAsync(@"C:\temp\MessyClassTest\MySampleFinancial.txt", $"{o.id},{o.personProfileType},{o.f},{o.y},{o.name}, {FULLNAME}");
            }
        }
        else
        {
            throw new Exception("Cannot do this");
        }

    }
}

public class TotoData
{
    public IEnumerable<dynamic> AccessDataSample()
    {
        yield return new { id = 1, personProfileType = "type1", f = 123f, y = 1999, name = "Doe1" };
        yield return new { id = 2, personProfileType = "type1", f = 124f, y = 1995, name = "Doe2" };
        yield return new { id = 3, personProfileType = "type2", f = 125f, y = 1998, name = "Doe3" };
        yield return new { id = 4, personProfileType = "type2", f = 126f, y = 1999, name = "Doe4" };
        yield return new { id = 5, personProfileType = "type2", f = 127f, y = 1997, name = "Doe5" };
    }
}

public class SampleDto
{
    public int Id { get; set; }
    public string ProfileType { get; set; }
    public float Amount { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
}