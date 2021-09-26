using BookStore.Business.Abstract;
using BookStore.Core.Constans;
using BookStore.Core.Entities.Concrete;
using BookStore.Core.Models.Response;
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
    public class AuthorService : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorService(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IResult<GetAuthorBooksViewModel> GetAuthorBook(Guid authorId)
        {
            try
            {
                var result = _authorDal.GetAuthorBook(authorId);

                if (result.Success)
                {
                    return new Result<GetAuthorBooksViewModel>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<GetAuthorBooksViewModel>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<GetAuthorBooksViewModel>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public IResult<List<Author>> GetAuthors()
        {
            try
            {
                var result = _authorDal.GetAuthors();

                if (result.Success)
                {
                    return new Result<List<Author>>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<List<Author>>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Author>>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }
    }
}