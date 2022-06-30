using Microsoft.AspNetCore.Mvc;
using BookStore.Repository;
using BookStore.models.Models;
using BookStore.models.ViewModels;

namespace BookStore.Api.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        UserRepository _repository = new UserRepository();

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetUsers());
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            User user = _repository.Login(model);
            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            User user = _repository.Register(model);

            if (user == null)
                return BadRequest();

            return Ok(user);
        }

    }
}
