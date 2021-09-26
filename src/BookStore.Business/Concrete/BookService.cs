using BookStore.Business.Abstract;
using BookStore.Core.Constans;
using BookStore.Core.Entities.Concrete;
using BookStore.Core.Utilities.Results.Abstract;
using BookStore.Core.Utilities.Results.Concrete;
using BookStore.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Concrete
{
    public class BookService : IBookService
    {
        private IBookDal _bookDal;

        public BookService(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult<bool> AddBookToStock(string bookId, int qty)
        {
            try
            {
                var result = _bookDal.AddBookToStock(bookId, qty);

                if (result.Success)
                {
                    return new Result<bool>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<bool>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<bool>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), false);
            }
        }

        public IResult<Book> CheckStock(string isbnNo)
        {
            try
            {
                var result = _bookDal.CheckStock(isbnNo);

                if (result.Success)
                {
                    return new Result<Book>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<Book>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<Book>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public IResult<List<Book>> CheckStockList(List<string> isbnNo)
        {
            try
            {
                var result = _bookDal.CheckStockList(isbnNo);

                if (result.Success)
                {
                    return new Result<List<Book>>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<List<Book>>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Book>>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public IResult<string> GetISBNByBookId(string bookId)
        {
            try
            {
                var result = _bookDal.GetISBNByBookId(bookId);

                if (result.Success)
                {
                    return new Result<string>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<string>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<string>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public IResult<bool> IsValidISBN(string isbnNo)
        {
            try
            {
                var result = _bookDal.IsValidISBN(isbnNo);

                if (result.Success)
                {
                    return new Result<bool>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<bool>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<bool>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), false);
            }
        }
    }
}