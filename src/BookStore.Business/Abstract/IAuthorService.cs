using BookStore.Core.Entities.Concrete;
using BookStore.Core.Models.Response;
using BookStore.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Abstract
{
    public interface IAuthorService
    {
        IResult<GetAuthorBooksViewModel> GetAuthorBook(Guid authorId);

        IResult<List<Author>> GetAuthors();
    }
}