using BookStore.Core.Data.Abstract;
using BookStore.Core.Entities.Concrete;
using BookStore.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Abstract
{
    public interface IBookDal : IEntityRepository<Book>
    {
        Result<Book> CheckStock(string isbnNo);

        Result<string> GetISBNByBookId(string bookId);

        Result<List<Book>> CheckStockList(List<string> isbnNo);

        Result<bool> IsValidISBN(string isbnNo);

        Result<bool> AddBookToStock(string bookId, int qty);
    }
}