using BookStore.Core.Constans;
using BookStore.Core.Data.Concrete.EntityFramework;
using BookStore.Core.Entities.Concrete;
using BookStore.Core.Utilities.Results.Concrete;
using BookStore.Data.Abstract;
using BookStore.Data.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Concrete
{
    public class EfBookDal : EfEntityRepositoryBase<Book, BookStoreDbContext>, IBookDal
    {
        public Result<bool> AddBookToStock(string bookId, int qty)
        {
            try
            {
                using (var context = new BookStoreDbContext())
                {
                    var result = context.Books
                      .Where(b => b.Id == new Guid(bookId))
                      .FirstOrDefault<Book>();

                    if (result != null)
                    {
                        result.QuantityLeft = qty;
                        context.SaveChanges();

                        return new Result<bool>(true, Messages.Successful, true);
                    }
                    else
                    {
                        return new Result<bool>(false, Messages.Unsuccessful, false);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result<bool>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), false);
            }
        }

        public Result<Book> CheckStock(string isbnNo)
        {
            try
            {
                using (var context = new BookStoreDbContext())
                {
                    var result = context.Books
                      .Where(b => b.ISBN == isbnNo)
                      .FirstOrDefault<Book>();

                    if (result != null)
                    {
                        return new Result<Book>(true, Messages.Successful, result);
                    }
                    else
                    {
                        return new Result<Book>(false, Messages.Unsuccessful, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result<Book>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public Result<List<Book>> CheckStockList(List<string> isbnNo)
        {
            try
            {
                using (var context = new BookStoreDbContext())
                {
                    var result = context.Books
                      .Where(b => isbnNo.Contains(b.ISBN)).ToList();

                    if (result != null)
                    {
                        return new Result<List<Book>>(true, Messages.Successful, result);
                    }
                    else
                    {
                        return new Result<List<Book>>(false, Messages.Unsuccessful, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Book>>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public Result<string> GetISBNByBookId(string bookId)
        {
            try
            {
                using (var context = new BookStoreDbContext())
                {
                    var result = context.Books
                      .Where(b => b.Id == new Guid(bookId))
                      .FirstOrDefault<Book>();

                    if (result != null)
                    {
                        return new Result<string>(true, Messages.Successful, result.ISBN);
                    }
                    else
                    {
                        return new Result<string>(false, Messages.Unsuccessful, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result<string>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public Result<bool> IsValidISBN(string isbnNo)
        {
            try
            {
                bool result = false;

                if (!string.IsNullOrEmpty(isbnNo))

                {
                    long j;

                    if (isbnNo.Contains('-')) isbnNo = isbnNo.Replace("-", "");

                    if (!Int64.TryParse(isbnNo, out j))
                        result = false;

                    int sum = 0;

                    for (int i = 0; i < 12; i++)
                    {
                        sum += Int32.Parse(isbnNo[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                    }

                    int remainder = sum % 10;
                    int checkDigit = 10 - remainder;
                    if (checkDigit == 10) checkDigit = 0;

                    result = (checkDigit == int.Parse(isbnNo[12].ToString()));
                }

                return new Result<bool>(result, Messages.Unsuccessful, result);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), false);
            }
        }
    }
}