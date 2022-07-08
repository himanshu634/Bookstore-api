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
        CartRepository _cartRepository = new CartRepository();

        [HttpGet]
        [Route("list/{userId}")]
        public IActionResult GetCartItems(int userId)
        {
            Cart carts = _cartRepository.GetCartByUserId(userId);
           // IEnumerable<CartModel> cartModels = carts.Select(c => new CartModel(c)); 
            return Ok(carts);
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
