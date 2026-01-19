using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.DAL.Abstracts;
using Test.DAL.Entities;
using Test.DAL.Repositories;
namespace Test.Pages
{
	public class AuthorDetailsModel : PageModel
	{
		private readonly IAuthorRepository _authorRepository;

		public AuthorDetailsModel(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public Author Author { get; set; }

		public IActionResult OnGet(int id)
		{
			Author = _authorRepository.GetById(id);
			if (Author == null) return RedirectToPage("/Library");
			return Page();
		}
	}
}