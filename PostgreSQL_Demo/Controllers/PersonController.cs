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
            Person person = new Person {Id= Guid.NewGuid().ToString(),Name=personView.Name,Age= personView.Age,FamlilyNumber = personView.FamilyNumber};
            _personService.Add(person);
            return Ok("Added!");
        }
        [HttpPut]
        public IActionResult UpdatePersonById([FromQuery] string Id, [FromBody] PersonView personView)
        {
            if (personView == null || string.IsNullOrEmpty(Id))
            {
                return BadRequest("Invalid request data");
            }

            // Retrieve the person to be updated
            Person existingPerson = _personService.GetAll()
                .FirstOrDefault(p => p.Id == Id);

            if (existingPerson == null)
            {
                return NotFound($"Person with ID {Id} not found");
            }

            // Update the existing person with the data from the request
            existingPerson.Name = personView.Name;
            existingPerson.Age = personView.Age;
            existingPerson.FamlilyNumber = personView.FamilyNumber;

            // Perform the update
            _personService.Update(existingPerson);

            // Return the updated person
            return Ok(existingPerson);
        }
        [HttpDelete]
        public IActionResult DeletePersonById(string id)
        {
            Person person = _personService.GetAll()
                .Find(p => p.Id == id);
            _personService.Delete(person);
            return Ok("Deleted!");
        }

    }
}
