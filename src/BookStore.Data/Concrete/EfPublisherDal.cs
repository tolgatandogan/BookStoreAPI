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
    public class EfPublisherDal : EfEntityRepositoryBase<Publisher, BookStoreDbContext>, IPublisherDal
    {
        public Result<GetPublisherBooksViewModel> GetPublisherBook(Guid publisherId)
        {
            GetPublisherBooksViewModel getPublisherBooksViewModel = new GetPublisherBooksViewModel();
            try
            {
                using (var context = new BookStoreDbContext())
                {
                    var result = context.Publishers
                      .Where(b => b.Id == publisherId)
                      .FirstOrDefault<Publisher>();

                    if (result != null)
                    {
                        getPublisherBooksViewModel.Publisher = result;

                        var bookList = context.Books
                      .Where(b => b.Id == result.Id).ToList();

                        if (bookList != null)
                        {
                            getPublisherBooksViewModel.BookList = bookList;
                        }

                        return new Result<GetPublisherBooksViewModel>(true, Messages.Successful, getPublisherBooksViewModel);
                    }
                    else
                    {
                        return new Result<GetPublisherBooksViewModel>(false, Messages.Unsuccessful, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result<GetPublisherBooksViewModel>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public Result<List<Publisher>> GetPublishers()
        {
            try
            {
                using (var context = new BookStoreDbContext())
                {
                    var result = context.Publishers.ToList();

                    if (result != null)
                    {
                        return new Result<List<Publisher>>(true, Messages.Successful, result);
                    }
                    else
                    {
                        return new Result<List<Publisher>>(false, Messages.Unsuccessful, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Publisher>>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }
    }
}