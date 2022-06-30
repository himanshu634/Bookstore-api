using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;
using BookStore.models.Models;

namespace BookStore.Repository
{
    public class UserRepository : BaseRepository
    {

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User Login(LoginModel model)
        {
            return  _context.Users.FirstOrDefault(c => c.Email.Equals(model.Email.ToLower()) && c.Password.Equals(model.Password));
        }

        public User Register(RegisterModel model)
        {
            User user = new User()
            {
                Firstname = model.Firstname,
                Email = model.Email,
                Lastname = model.Lastname,
                Roleid = model.Roleid,
                Password = model.Password
            };

            var entry = _context.Users.Add(user);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
