# CdmTestCase
> Questions

- Extension methods: purpose
- records: purpose?
- Security : IDP / OAuth / IAM

> Debug

- make the project build
- make the endpoint GET work

> Refactoring MessyClass

- SOLID
- Replace Hard coded values
- Naming conventions
- Dependency => Notification, Logs
- foreach => filter on following IF
- Add Enum for ProfileTypes
- foreach => Use polymorphism (Factory, Strategy)
- Parallel.ForEach vs Task.WhenAll

> CreatePeronRequestHandler
- Add Manager

- Add Director

> TDD: Employee, Manager, Director classes
 - Add method GetSalary (depending on the current age) with the following business rules
 - If person's age > 18
   - Compute salary => 60000
 - If person's age > 18 and < 40
   - Compute salary => 85000
 - If person's age > 40
   - Compute salary => 100000
 - If person is a manager
   - Add extra 15%
 - Add extension method to Map to a Dto with only ID and Name
