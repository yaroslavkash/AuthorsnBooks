using Test.DAL.Abstracts;

namespace Test.Services
{
	public class AuthorService
	{
		private readonly IAuthorRepository _authorRepository;

		public AuthorService(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public void DeleteAuthor(int id)
		{
			var author = _authorRepository.GetById(id);

			if (author == null) return;

			if (author.Books != null && author.Books.Any())
			{
				throw new Exception($"cant delete author {author.FirstName} {author.LastName} cuz he has books.");
			}

			_authorRepository.Delete(id);
		}
	}

	// ! лдодати білдер в програм сс
}