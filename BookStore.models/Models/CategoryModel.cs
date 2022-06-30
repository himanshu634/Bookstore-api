using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;

namespace BookStore.models.Models
{
    public class CategoryModel
    {

        public CategoryModel() { }
        public CategoryModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;  
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
 