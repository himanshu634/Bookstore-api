using Microsoft.AspNetCore.Mvc;
using BookStore.models.Models;
using BookStore.Repository;
using BookStore.models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BookStore.Api.Controllers
{

    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        readonly CartRepository _cartRepository = new CartRepository();
        readonly BookRepository _bookRepository = new BookRepository();

        private  class Cart2
        {
            public Cart2(int Id, int UserId, int Quantity, Book Book)
            {
                this.Id = Id;
                this.UserId = UserId;
                this.Quantity = Quantity;
                this.Book = Book;
            }
            public int Id { get; set; }
            public int UserId { get; set; }
            public int Quantity { get; set; }
            public Book Book { get; set; }
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems(string keyword)
        {
            List<Cart> carts = _cartRepository.GetCartItems(keyword);
            IEnumerable<CartModel> cartModels = carts.Select(c => new CartModel(c)); 
            return Ok(cartModels);
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetCartById(int id)
        {
            List<Cart> _list = _cartRepository.GetCart(id);
            IEnumerable<Cart2> _listModels = _list.Select(c => new Cart2(c.Id, c.UserId, c.Quantity, _bookRepository.GetBook(c.BookId)));
            return Ok(_listModels);
        }


        [HttpPost]
        [Route("add")]    
       public IActionResult AddCart(CartModel cartModel)
        {
            if(cartModel == null)
            {
                return BadRequest();
            }
            Cart cart = new Cart()
            {
                Id = cartModel.Id,
                BookId = cartModel.BookId,
                Quantity = 1,
                UserId = cartModel.UserId,
            };

            return Ok(_cartRepository.AddCart(cart));

        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCart(CartModel cartModel)
        {
            if(cartModel == null)
            {
                return BadRequest();
            }

            Cart cart = new Cart()
            {
                Id = cartModel.Id,
                UserId = cartModel.UserId,
                BookId = cartModel.BookId,
                Quantity = cartModel.Quantity,
            };

            return Ok(_cartRepository.UpdateCart(cart));
        }


        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteCart(int Id)
        {
            if(Id == 0)
            {
                return BadRequest();
            }

            return Ok(_cartRepository.DeleteCart(Id));
        }
    }

}
