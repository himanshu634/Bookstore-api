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
    [Route("cart")]
    public class CartController : Controller
    {
        CartRepository _cartRepository = new CartRepository();

        [HttpGet]
        [Route("")]
        public IActionResult GetCartItems(string keyword)
        {
            List<Cart> carts = _cartRepository.GetCartItems(keyword);
            IEnumerable<CartModel> cartModels = carts.Select(c => new CartModel(c)); 
            return Ok(cartModels);
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
                Bookid = cartModel.BookId,
                Quantity = 1,
                Userid = cartModel.UserId,
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
                Userid = cartModel.UserId,
                Bookid = cartModel.BookId,
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
