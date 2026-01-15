using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DAL.Abstracts;
using Test.DAL.Entities;

namespace Test.DAL
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _db;
		public UserRepository(AppDbContext db)
		{
			_db = db;
		}
		public void AddUser(User user)
		{
			_db.Users.Add(user);
			_db.SaveChanges();
		}

		public User GetById(int id)
		{
			return _db.Users.FirstOrDefault(u => u.ID == id);
		}
		public List<User> GetAll()
		{
			return _db.Users.ToList();
		}
	}
}
