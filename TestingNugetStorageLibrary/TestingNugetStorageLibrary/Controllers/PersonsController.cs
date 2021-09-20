using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorageNuGetPackage;
using StorageNuGetPackage.Receiver;
using StorageNuGetPackage.Sender;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingNugetStorageLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {


        private readonly IStorageSender _senderStorage;
        private readonly IStorageReceiver<Person> _receiverStorage;

        public PersonsController(IStorageSender senderStorage, IStorageReceiver<Person> receiverStorage)
        {
            _senderStorage = senderStorage;
            _receiverStorage = receiverStorage;
        }


        [HttpGet]
        [SwaggerResponse(200, Description = "Success", Type = typeof(IEnumerable<Person>))]
        [SwaggerResponse(204, "No Content", typeof(string), Description = "No Content", StatusCode = 204, Type = typeof(string))]
        [SwaggerResponse(401, Description = "Unauthorized", Type = typeof(string))]
        [CustomAuthorizationAttribute]
        public async Task<IActionResult> GetAllPersons()
        {

            var allPersons = _receiverStorage.GetAllPersons();
            return Ok(allPersons);
        }

        [HttpPost]
        [CustomAuthorizationAttribute]
        public async Task<IActionResult> AddPerson(Person p)
        {
            var reponseResult = _senderStorage.SaveRecord(p);
            return Ok(reponseResult);
        }
    }
}
