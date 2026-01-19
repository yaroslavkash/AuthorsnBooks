using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.DAL.Abstracts;
using Test.DAL.Entities;

namespace Test.Pages
{
	public class EditBookModel : PageModel
	{
		private readonly IBookRepository _bookRepository; // отримання книги
		private readonly IAuthorRepository _authorRepository; // завантаження всіхї авторів

		public EditBookModel(IBookRepository bookRepository, IAuthorRepository authorRepository)
		{
			_bookRepository = bookRepository;
			_authorRepository = authorRepository;
		}

		[BindProperty]
		public Book Book { get; set; }
		public SelectList AuthorsList { get; set; }

		public IActionResult OnGet(int id)
		{
			Book = _bookRepository.GetById(id);
			if (Book == null) return RedirectToPage("/Library");

			AuthorsList = new SelectList(_authorRepository.GetAll(), "Id", "FullName");
			return Page();
		}

		public IActionResult OnPostUpdate()
		{
			if (!ModelState.IsValid)
			{
				AuthorsList = new SelectList(_authorRepository.GetAll(), "Id", "FullName");
				return Page();
			}

			_bookRepository.Update(Book);
			return RedirectToPage("/Library");
		}

		public IActionResult OnPostDelete()
		{
			_bookRepository.Delete(Book.Id);
			return RedirectToPage("/Library");
		}
	}
}