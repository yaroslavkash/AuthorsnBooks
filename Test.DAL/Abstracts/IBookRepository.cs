using System.Collections.Generic;
using Test.DAL.Entities;

namespace Test.DAL.Abstracts
{
	public interface IBookRepository
	{
		List<Book> GetAll();
		void Add(Book book);
		Book GetById(int id);
		void Update(Book book);
		void Delete(int id);
	}
}