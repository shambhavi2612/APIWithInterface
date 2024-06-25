using CRUDThroughInterface.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDThroughInterface.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly AppDbContext _dbContext;                                 //Declares a private read-only field _dbContext to hold the database context instance.

        public StudentRepository(AppDbContext dbContext)                          // Constructor that initializes the _dbContext field. It throws an ArgumentNullException if dbContext is null.
        {
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		public IEnumerable<Students> GetStudents()
		{
			try
			{
				return _dbContext.Students.ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetStudents: {ex.Message}");
				throw;
			}
		}

		public Students GetStudentById(int id)
		{
			try
			{
				return _dbContext.Students.FirstOrDefault(p => p.StudentId == id);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetStudentById: {ex.Message}. Id: {id}");
				throw;
			}
		}

		public Students CreateStudent(Students student)
		{
			try
			{
				_dbContext.Students.Add(student);
				_dbContext.SaveChanges();
				return student;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CreateStudent: {ex.Message}");
				throw;
			}
		}

		public void UpdateStudent(int id, Students updatedStudent)
		{
			try
			{
				var studentToUpdate = _dbContext.Students.FirstOrDefault(p => p.StudentId == id);
				if (studentToUpdate != null)
				{
					studentToUpdate.StudentName = updatedStudent.StudentName;
					studentToUpdate.StudentAge = updatedStudent.StudentAge;
					studentToUpdate.StudentPermanentAddress = updatedStudent.StudentPermanentAddress;
					studentToUpdate.StudentEmail = updatedStudent.StudentEmail;

					_dbContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in UpdateStudent: {ex.Message}. Id: {id}");
				throw;
			}
		}

		public void DeleteStudent(int id)
		{
			try
			{
				var studentToDelete = _dbContext.Students.FirstOrDefault(p => p.StudentId == id);
				if (studentToDelete != null)
				{
					_dbContext.Students.Remove(studentToDelete);
					_dbContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in DeleteStudent: {ex.Message}. Id: {id}");
				throw;
			}
		}
	}
}
