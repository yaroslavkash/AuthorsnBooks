using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.DAL.Abstracts;
using Test.Models;
using Test.DAL.Entities;
using System.Linq;

namespace Test.Pages
{
	public class IndexInputModel : PageModel
	{
		private readonly IUserRepository _userRepository;

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CreatedDate { get; set; }

		[BindProperty]
		public UserInputModel Input { get; set; }

		public IndexInputModel(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public void OnGet()
		{
			var user = _userRepository.GetAll().LastOrDefault();
			if (user != null)
			{
				FirstName = user.FirstName;
				LastName = user.LastName;
				CreatedDate = user.CreatedDate.ToShortDateString();
			}
		}

		public void OnPostSave()
		{
			if (!ModelState.IsValid)
			{
				return;
			}

			var newUser = new User
			{
				FirstName = Input.FirstName,
				LastName = Input.LastName,
				CreatedDate = DateTime.Now
			};

			_userRepository.AddUser(newUser);
			OnGet();
		}

		public void OnPostDelete()
		{
			FirstName = "";
			LastName = "";
			CreatedDate = "";
		}
	}
}