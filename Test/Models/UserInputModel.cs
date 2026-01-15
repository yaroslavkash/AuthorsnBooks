using System.ComponentModel.DataAnnotations; 
namespace Test.Models 
{
	public class UserInputModel
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
	}
}