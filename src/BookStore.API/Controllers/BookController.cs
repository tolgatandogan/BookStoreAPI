using BookStore.Business.Abstract;
using BookStore.Core.Entities.Concrete;
using BookStore.Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Route("api/book/checkstok")]
        [HttpPost]
        public Result<Book> CheckStock(string isbnNo)
        {

            var result = _bookService.CheckStock(isbnNo);

            if (!result.Success)
            {
                return new Result<Book>(result.Success, result.Message, result.Data);
            }

            return new Result<Book>(true, string.Format("{0}", result.Message), result.Data);
        }

        [Route("api/book/isvalidisbn")]
        [HttpPost]
        public Result<bool> IsValidISBN(string isbnNo)
        {

            var result = _bookService.IsValidISBN(isbnNo);

            if (!result.Success)
            {
                return new Result<bool>(result.Success, result.Message, result.Data);
            }

            return new Result<bool>(true, string.Format("{0}", result.Message), result.Data);
        }

        [Route("api/book/addbooktostock")]
        [HttpPost]
        public Result<bool> AddBookToStock(string bookId, int qty)
        {

            string message = string.Empty;
            bool dataResult = false;

            var ISBN = _bookService.GetISBNByBookId(bookId);

            var checkISBN = IsValidISBN(ISBN.Data);

            if (checkISBN.Success)
            {
                var result = _bookService.AddBookToStock(bookId, qty);

                message = result.Message;
                dataResult = result.Data;
                if (!result.Success)
                {
                    return new Result<bool>(result.Success, result.Message, result.Data);
                }
            }
            else
            {
                return new Result<bool>(false, "ISBN is invalid.", false);
            }

            return new Result<bool>(true, string.Format("{0}", message), dataResult);
        }

        [Route("api/book/checkstocklist")]
        [HttpPost]
        public Result<List<Book>> CheckStockList(List<string> isbnNo)
        {

            var result = _bookService.CheckStockList(isbnNo);

            if (!result.Success)
            {
                return new Result<List<Book>>(result.Success, result.Message, result.Data);
            }

            return new Result<List<Book>>(true, string.Format("{0}", result.Message), result.Data);
        }
    }
}
