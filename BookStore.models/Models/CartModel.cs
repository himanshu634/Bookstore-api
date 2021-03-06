using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;

namespace BookStore.models.Models
{
    public class CartModel
    {
        public CartModel() { }

        public CartModel(Cart cart)
        {
            Id=cart.Id;
            UserId=cart.UserId;
            BookId=cart.BookId;
            Quantity=cart.Quantity;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }
    }
}
