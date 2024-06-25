using CRUDThroughInterface.Models;
using static CRUDThroughInterface.Models.Students;

namespace CRUDThroughInterface.Repositories
{
	public interface IStudentRepository
	{
		IEnumerable<Students> GetStudents();                            // to retrieve the list of students
		Students GetStudentById(int id);
		Students CreateStudent(Students student);
		void UpdateStudent(int id, Students updatedStudent);
		void DeleteStudent(int id);
	}
}
