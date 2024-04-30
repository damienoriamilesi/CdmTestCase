using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using SampleAPI.ToRefactor;

namespace SampleAPI.Features.CreatePerson
{
    /// <summary>
    /// Handler to manage Person resource creation
    /// </summary>
    public class CreatePersonRequestHandler : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
    {
        private readonly PersonRepository _personRepository;

        public CreatePersonRequestHandler(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            if (request.PersonType == Enums.PersonTypes.Employee)
            {
                var employee = new Employee();
                _personRepository.AddEmployee(employee);
                _personRepository.Save();
                
                var response = new CreatePersonResponse(employee);
                return Task.FromResult(response);
            }
            //Add Manager

            //Add Director

            throw new Exception("Unknown type of person");
        }
    }
    
    public record CreatePersonRequest(Enums.PersonTypes PersonType) : IRequest<CreatePersonResponse>;
    public record CreatePersonResponse(Person Person);





    public abstract class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual int GetSalary() => 60000;

    }
    
    /// <inheritdoc />
    public class Employee : Person
    {
        public string Position { get; set; }
        public float EmployeeNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
    }

    public class Manager : Person
    {
        public override int GetSalary()
        {
            return base.GetSalary() + 6000;
        }
    }

    public class Director : Person 
    {
        override int GetSalary() => base.GetSalary() + 12000;

    }

}
