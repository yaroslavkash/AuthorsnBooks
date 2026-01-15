using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DAL.Entities;

namespace Test.DAL.Abstracts
{
	public interface IUserRepository
	{
		User GetById(int id);

		List<User> GetAll();
		void AddUser(User user);
	}
}