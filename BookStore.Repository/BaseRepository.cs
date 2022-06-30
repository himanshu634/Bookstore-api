using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;

namespace BookStore.Repository
{
    public class BaseRepository
    {
        protected readonly bksContext _context = new bksContext();
    }
}
