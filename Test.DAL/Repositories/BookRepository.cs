using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Linq;
using Test.DAL.Abstracts;
using Test.DAL.Entities;

namespace Test.DAL.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly AppDbContext _context;

		public BookRepository(AppDbContext context)
		{
			_context = context;
		}

		public void Add(Book book)
		{
			_context.Books.Add(book);
			_context.SaveChanges();
		}

		public List<Book> GetAll()
		{
			// інклюд завантажує дані з зв'язаної таблиці автора
			return _context.Books
				.Include(b => b.Author)
				.ToList();
		}
	}
}