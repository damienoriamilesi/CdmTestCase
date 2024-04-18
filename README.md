# CdmTestCase

> Refacoring MessyClass
> Test Messy class
> TDD
 - Add method SetSalary (depending on the current age) with the following business rules 
 - Rename Foo => Person
 - If person's age > 18
   - Compute salary => 60000
 - If person's age > 18 and < 40
   - Compute salary => 85000
 - If person's age > 40
   - Compute salary => 100000
 - If person is a manager
   - Add extra 15%
   
   
   
   	1. REFACTORING
		○ Messy Class
			§ CTOR : Instanciation new FooInject instead
				Add interface to Foo
				Inject into ctor
				Remove new Foo in ctor
				Rename _t  => _foo
			§ DoSomethingSpecial
				FileAppenAllText 
					® Add Async
					® Move hardcoded path to settings
					® Add dependency to DAL and File System?
				Too many arguments in the signature
				Float f : Amount to pay => decimal + rename
				Invert if statement to Fail Fast
				No Exception => BusinessException
			Foo class
				Change string ProfileType => Enum
				
	2. Testing
		File or Folder doesn't exist??
TDD ?
