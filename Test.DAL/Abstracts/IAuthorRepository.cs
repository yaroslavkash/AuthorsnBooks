using System.Collections.Generic;
using Test.DAL.Entities;

namespace Test.DAL.Abstracts
{
	public interface IAuthorRepository
	{
		List<Author> GetAll();
		void Add(Author author);
		Author GetById(int id);
		bool IsDuplicate(string firstName, string lastName);
		void Update(Author author);
		void Delete(int id);
	}
}