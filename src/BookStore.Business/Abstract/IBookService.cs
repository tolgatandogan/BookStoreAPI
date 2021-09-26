using BookStore.Core.Entities.Concrete;
using BookStore.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Abstract
{
    public interface IBookService
    {
        IResult<Book> CheckStock(string isbnNo);

        IResult<List<Book>> CheckStockList(List<string> isbnNo);

        IResult<bool> IsValidISBN(string isbnNo);

        IResult<bool> AddBookToStock(string bookId, int qty);

        IResult<string> GetISBNByBookId(string bookId);
    }
}