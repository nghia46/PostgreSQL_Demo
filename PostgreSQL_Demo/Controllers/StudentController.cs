using AppData;
using AppData.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PostgreSQL_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(ServiceBase<Student> studentService) : ControllerBase
    {
        [HttpGet]
        public  IActionResult GetPerson()
        {
            var persons = studentService.GetAll();
            return Ok(persons);
        }
        [HttpPost]
        public IActionResult AddPerson(StudentView studentView)
        {
            var student = new Student {Id= Guid.NewGuid().ToString(),Name=studentView.Name,Age= studentView.Age,Gpa = studentView.Gpa};
            studentService.Add(student);
            return Ok("Added!");
        }
        [HttpPut]
        public IActionResult UpdatePersonById([FromQuery] string Id, [FromBody] StudentView studentView)
        {
            if (studentView == null || string.IsNullOrEmpty(Id))
            {
                return BadRequest("Invalid request data");
            }

            // Retrieve the person to be updated
            var existingStudent = studentService.GetAll()
                .FirstOrDefault(p => p.Id == Id);

            if (existingStudent == null)
            {
                return NotFound($"Person with ID {Id} not found");
            }

            // Update the existing person with the data from the request
            existingStudent.Name = studentView.Name;
            existingStudent.Age = studentView.Age;
            existingStudent.Gpa = studentView.Gpa;

            // Perform the update
            studentService.Update(existingStudent);

            // Return the updated person
            return Ok(existingStudent);
        }
        [HttpDelete]
        public IActionResult DeletePersonById(string id)
        {
            Student student = studentService.GetAll()
                .Find(p => p.Id == id);
            studentService.Delete(student);
            return Ok("Deleted!");
        }
    }
}
