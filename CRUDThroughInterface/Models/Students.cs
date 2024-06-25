using System.ComponentModel.DataAnnotations;

namespace CRUDThroughInterface.Models
{
	public class Students
	{
		[Key]
		public int StudentId { get; set; }      // Identity column
		public string? StudentName { get; set; }
		public int StudentAge { get; set; }
		public string? StudentPermanentAddress { get; set; }
		public string? StudentEmail { get; set; }
	}
}
