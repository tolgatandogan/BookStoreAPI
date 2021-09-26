using BookStore.Core.Constans;
using BookStore.Core.Data.Concrete.EntityFramework;
using BookStore.Core.Entities.Concrete;
using BookStore.Core.Models.Response;
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
    public class EfAuthorDal : EfEntityRepositoryBase<Author, BookStoreDbContext>, IAuthorDal
    {
        public Result<GetAuthorBooksViewModel> GetAuthorBook(Guid authorId)
        {
            GetAuthorBooksViewModel getAuthorBooksViewModel = new GetAuthorBooksViewModel();
            try
            {
                using (var context = new BookStoreDbContext())
                {
                    var result = context.Authors
                      .Where(b => b.Id == authorId)
                      .FirstOrDefault<Author>();

                    if (result != null)
                    {
                        getAuthorBooksViewModel.Author = result;

                        var bookList = context.Books
                      .Where(b => b.AuthorId == result.Id).ToList();

                        if (bookList != null)
                        {
                            getAuthorBooksViewModel.BookList = bookList;
                        }

                        return new Result<GetAuthorBooksViewModel>(true, Messages.Successful, getAuthorBooksViewModel);
                    }
                    else
                    {
                        return new Result<GetAuthorBooksViewModel>(false, Messages.Unsuccessful, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result<GetAuthorBooksViewModel>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public Result<List<Author>> GetAuthors()
        {
            try
            {
                using (var context = new BookStoreDbContext())
                {
                    var result = context.Authors.ToList();

                    if (result != null)
                    {
                        return new Result<List<Author>>(true, Messages.Successful, result);
                    }
                    else
                    {
                        return new Result<List<Author>>(false, Messages.Unsuccessful, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Author>>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }
    }
}