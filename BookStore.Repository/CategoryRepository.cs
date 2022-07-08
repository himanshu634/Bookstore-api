using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;
using BookStore.models.Models;

namespace BookStore.Repository
{
    public class CategoryRepository : BaseRepository
    {
       public ListResponse<Category> GetCategories(int pageIndex, int pageSize, string keyword)
        {
            var query = _context.Categories.AsQueryable();

            int TotalRecords = query.Count();
            if (pageSize != 0)
            {
                if (pageIndex != 0)
                {
                    query = query.Where(category => (keyword == default || category.Name.ToLower().Contains(keyword.ToLower()))).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    if (keyword != default)
                    {
                        TotalRecords = query.Count();
                    }
                }
            }

            var Records = query.ToList();



            return new ListResponse<Category>()
            {
                Records = Records,
                TotalRecords = TotalRecords,
            };
            /* keyword = keyword?.ToLower()?.Trim();
             var query = _context.Categories.Where(c => keyword == null || c.Name.Contains(keyword)).AsQueryable();
             int totalRecords = query.Count();
             List<Category> categories = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

             return new ListResponse<Category>()
             {
                 Results = categories,
                 TotalRecords = totalRecords,
             };*/
        }

        public Category GetCategory(int Id)
        {
           return _context.Categories.FirstOrDefault(c => c.Id == Id);
        }

        public Category AddCategory(Category category)
        {
            var entry = _context.Categories.Add(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Category UpdateCategory(Category category)
        {
            var entry = _context.Categories.Update(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCategory(int Id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == Id);
            if (category == null)
                return false;
            _context.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}
