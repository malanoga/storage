using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {

        private readonly ILogger<StorageController> _logger;

        public StorageController(ILogger<StorageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Task<IEnumerable<Person>> GetPersons()
        {
            return Task.FromResult(People.GetPeople().AsEnumerable());
        }
        [HttpPost]
        public Task<string> GetPersons(Person person)
        {
            return Task.FromResult(People.AddPerson(person));
        }
        [HttpGet("name")]
        public Task<Person> GetPersonByName(string name)
        {
            return Task.FromResult(People.GetPersonByName(name));
        }
    }
}
