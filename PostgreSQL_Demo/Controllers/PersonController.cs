using AppData;
using AppData.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;

namespace PostgreSQL_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ServiceBase<Person> _personService;
        public PersonController(ServiceBase<Person> personService) {
            _personService = personService;
        }
        [HttpGet]
        public  IActionResult GetPerson()
        {
            List<Person> persons = _personService.GetAll();
            return Ok(persons);
        }
        [HttpPost]
        public IActionResult AddPerson(PersonView personView)
        {
            Person person = new Person {Id= Guid.NewGuid().ToString(),Name=personView.Name,Age= personView.Age};
            _personService.Add(person);
            return Ok("Added!");
        }
    }
}
