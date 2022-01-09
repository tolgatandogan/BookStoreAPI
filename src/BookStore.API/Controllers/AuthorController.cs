using BookStore.Business.Abstract;
using BookStore.Core.Entities.Concrete;
using BookStore.Core.Models.Response;
using BookStore.Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorService _authorService;


        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Route("api/author/getauthors")]
        [HttpGet]
        public Result<List<Author>> GetAuthors()
        {

            var result = _authorService.GetAuthors();

            if (!result.Success)
            {
                return new Result<List<Author>>(result.Success, result.Message, result.Data);
            }

            return new Result<List<Author>>(true, string.Format("{0}", result.Message), result.Data);
        }

        [Route("api/author/getauthorbook")]
        [HttpPost]
        public Result<GetAuthorBooksViewModel> GetAuthorBook(Guid authorId)
        {

            var result = _authorService.GetAuthorBook(authorId);

            if (!result.Success)
            {
                return new Result<GetAuthorBooksViewModel>(result.Success, result.Message, result.Data);
            }

            return new Result<GetAuthorBooksViewModel>(true, string.Format("{0}", result.Message), result.Data);
        }
    }
}
