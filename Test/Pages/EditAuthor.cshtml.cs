using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.DAL.Abstracts;
using Test.DAL.Entities;
using Test.Services;

namespace Test.Pages
{
	public class EditAuthorModel : PageModel
	{
		private readonly IAuthorRepository _authorRepository; // беру зберігаю дані
		private readonly AuthorService _authorService; // чи можна видаляти 

		public EditAuthorModel(IAuthorRepository authorRepository, AuthorService authorService)
		{
			_authorRepository = authorRepository;
			_authorService = authorService;
		}

		[BindProperty]
		public Author Author { get; set; }

		public string ErrorMessage { get; set; }

		public IActionResult OnGet(int id)
		{
			Author = _authorRepository.GetById(id);
			if (Author == null) return RedirectToPage("/Library");
			return Page();
		}

		public IActionResult OnPostUpdate()
		{
			if (!ModelState.IsValid) return Page();
			_authorRepository.Update(Author);
			return RedirectToPage("/Library");
		}

		public IActionResult OnPostDelete()
		{
			try // пробую видалити через сервіс, якщо не вийшло - ловлю ексепшн
			{
				_authorService.DeleteAuthor(Author.Id);
				return RedirectToPage("/Library");
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				Author = _authorRepository.GetById(Author.Id); // Перезавантажуємо дані
				return Page();
			}
		}
	}
}