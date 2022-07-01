using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.Models;
using BookStore.models.ViewModels;

namespace BookStore.Repository
{
    public class CartRepository : BaseRepository
    {
        public List<Cart> GetCartItems(string keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Carts.Include(c => c.Book).Where(c => keyword == null || c.Book.Name.ToLower().Contains(keyword)).AsQueryable();//Where(c => keyword == null || c.Id )
            return query.ToList();
        }
        public Cart GetCart(int Id)
        {
            return _context.Carts.FirstOrDefault(c => c.Id == Id);
         }

        public Cart AddCart(Cart cart)
        {
            var entry = _context.Carts.Add(cart);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Cart UpdateCart(Cart cart)
        {
            var entry = _context.Carts.Update(cart);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCart(int Id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == Id);
            if(cart == null)
            {
                return false;
            }

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            return true; 
        }

    }

    
}

