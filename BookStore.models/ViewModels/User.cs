using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.models.ViewModels
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Ordermsts = new HashSet<Ordermst>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Ordermst> Ordermsts { get; set; }
    }
}
