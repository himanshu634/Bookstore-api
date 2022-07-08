using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;

namespace BookStore.models.Models
{
    public class ListResponse<T> where T: class
    {
        public IEnumerable<T> Records { get; set; } 

       public int TotalRecords { get; set; }
    }
}
