using SampleAPI.ToRefactor;

namespace SampleAPI.Tests;

public class MessyClassTest
{
    [Fact]
    public async Task Test1()
    {
        var messyClass = new MessyClass();
        await messyClass.DoSomethingSpecial(true, "type2", 12, 1998, "John");
    }
}