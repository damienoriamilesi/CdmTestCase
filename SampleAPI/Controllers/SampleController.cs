using MediatR;
using Microsoft.AspNetCore.Mvc;
using static SampleAPI.Controllers.SampleController;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SampleController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSampleObjectRequest request)
        {
            // TODO > Use mediatR to decouple and call the underlying business logic code
            // TODO > ToRefactor/AnotherSampleController could help
            throw new NotImplementedException();
        }


        public class CreateSampleObjectRequest
        {
            public SampleObjectTypes SampleObjectType { get; set; }
        }

        public enum SampleObjectTypes
        {
            Sample1,
            Sample2,
            Sample3
        }

        public enum SearchCriteriaModes
        {
            Even,
            MoreThan42,
            Top21,
            All
        }

        public class SampleObject
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }
        }
    }

    public class FakeGenerator
    {
        public static IEnumerable<SampleObject> GenerateSampleObjects(int count = 50)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new SampleObject { Name = $"Name_{i}" };
            }
        }
    }
}
