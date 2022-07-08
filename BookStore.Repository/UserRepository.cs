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
                FirstName = model.FirstName,
                Email = model.Email,
                LastName = model.LastName,
                RoleId = model.RoleId,
                Password = model.Password
            };

            var entry = _context.Users.Add(user);
            _context.SaveChanges();
            return entry.Entity;
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
