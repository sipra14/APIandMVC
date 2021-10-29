using CrudApi.Data;
using CrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Controllers
{   
    [Route("api/[Controller]")]
    public class StudentController : Controller
    {
        private Context _context;
        public StudentController(Context context)
        {
            _context = context;
        }
   //Get All The Students
        [HttpGet]
        public List<Student> Get()
        {
            return _context.students.ToList();
        }
   //Get Single Student
        [HttpGet("{Id}")]
        public Student GetStudent(int Id)
        {
            var student = _context.students.Where(a => a.Id == Id).SingleOrDefault();
            return student;
        }
   //Create New Student
        [HttpPost]
        public IActionResult PostStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            _context.students.Add(student);
            _context.SaveChanges();

            return Ok();
        }

     //Delete a student
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
