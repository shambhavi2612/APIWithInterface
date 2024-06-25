using CRUDThroughInterface.Models;
using CRUDThroughInterface.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUDThroughInterface.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentRepository _studentRepository;    // : Declares a private read-only field _studentRepository to hold the repository instance.

        public StudentsController(IStudentRepository studentRepository)   // Constructor that initializes the _studentRepository field. This uses dependency injection to inject an instance of IStudentRepository.
        {
			_studentRepository = studentRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Students>> GetStudents()
		{
			return Ok(_studentRepository.GetStudents());
		}

		[HttpGet("{id}")]
		public ActionResult<Students> GetStudentById(int id)
		{
			var student = _studentRepository.GetStudentById(id);
			if (student == null)
			{
				return NotFound();
			}
			return Ok(student);
		}

		[HttpPost]
		public ActionResult<Students> CreateStudent(Students student)
		{
			var createdStudent = _studentRepository.CreateStudent(student);
			return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateStudent(int id, Students student)
		{
			var existingStudent = _studentRepository.GetStudentById(id);
			if (existingStudent == null)
			{
				return NotFound();
			}

			_studentRepository.UpdateStudent(id, student);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteStudent(int id)
		{
			var existingStudent = _studentRepository.GetStudentById(id);
			if (existingStudent == null)
			{
				return NotFound();
			}

			_studentRepository.DeleteStudent(id);
			return NoContent();
		}
	}
}
