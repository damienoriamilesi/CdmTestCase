using SampleAPI.Features.CreatePerson;
using SampleAPI.ToRefactor;

namespace SampleAPI.Tests;

public class MessyClassTest
{
    private readonly MessyClass _messyClass;

    public MessyClassTest()
    {
        //_messyClass = new MessyClass();
    }
    
    [Fact]
    public void GetSalary_WhenManager_ShouldHaveBonus()
    {
        //Arrange
        Person manager = new Manager();
        
        //Act
        var salary = manager.GetSalary();
        
        //Assert
        Assert.Equal(60000 + 6000, salary);
    }
    
    [Fact]
    public void GetSalary_WhenDirector_ShouldHaveBonus()
    {
        Person director = new Director();

    }
}