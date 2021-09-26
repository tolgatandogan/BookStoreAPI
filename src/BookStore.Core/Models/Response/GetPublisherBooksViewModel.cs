using BookStore.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Response
{
    public class GetPublisherBooksViewModel
    {
        public List<Book> BookList { get; set; } = new List<Book>();

        public Publisher Publisher { get; set; }
    }
}