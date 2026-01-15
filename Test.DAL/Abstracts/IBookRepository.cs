using System.Collections.Generic;
using Test.DAL.Entities;

namespace Test.DAL.Abstracts
{
	public interface IBookRepository
	{
		List<Book> GetAll();
		void Add(Book book);
	}
}