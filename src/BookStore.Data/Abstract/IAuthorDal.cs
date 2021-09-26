using BookStore.Core.Data.Abstract;
using BookStore.Core.Entities.Concrete;
using BookStore.Core.Models.Response;
using BookStore.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Abstract
{
    public interface IAuthorDal : IEntityRepository<Author>
    {
        Result<GetAuthorBooksViewModel> GetAuthorBook(Guid authorId);

        Result<List<Author>> GetAuthors();
    }
}