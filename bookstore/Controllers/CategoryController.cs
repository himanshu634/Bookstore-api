using Microsoft.AspNetCore.Mvc;
using BookStore.Repository;
using BookStore.models.Models;
using System.Linq;
using BookStore.models.ViewModels;

namespace BookStore.Api.Controllers
{

    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {

        CategoryRepository _categoryRepository = new CategoryRepository();

        [Route("")]
        [HttpGet]
        public IActionResult GetCategories(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            var categories = _categoryRepository.GetCategories(pageIndex, pageSize, keyword);

            ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
            {
                Results = categories.Results.Select(c => new CategoryModel(c)),
                TotalRecords = categories.TotalRecords,
            };

            return Ok(listResponse);

        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetCategory(int Id)
        {
            try
            {
                CategoryModel categoryModel = new CategoryModel(_categoryRepository.GetCategory(Id));
                return Ok(categoryModel);
            }catch(System.Exception ex)
            {
                return NotFound(ex.Message);
            } 
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name
            };

            Category response = _categoryRepository.AddCategory(category);

            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name
            };

            Category response = _categoryRepository.UpdateCategory(category);

            return Ok(new CategoryModel(response));
        }

        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult DeleteCategory(int Id)
        {
            bool result = _categoryRepository.DeleteCategory(Id);

            if (result)
            {
                return Ok("Item Deleted");
            }
            return NotFound();
        }
    }
}
