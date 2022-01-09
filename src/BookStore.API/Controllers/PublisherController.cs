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
    public class PublisherController : ControllerBase
    {
        IPublisherService _publisherService;


        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [Route("api/publisher/getpublishers")]
        [HttpGet]
        public Result<List<Publisher>> GetPublishers()
        {

            var result = _publisherService.GetPublishers();

            if (!result.Success)
            {
                return new Result<List<Publisher>>(result.Success, result.Message, result.Data);
            }

            return new Result<List<Publisher>>(true, string.Format("{0}", result.Message), result.Data);
        }

        [Route("api/publisher/getpublisherbook")]
        [HttpPost]
        public Result<GetPublisherBooksViewModel> GetPublisherBook(Guid publisherId)
        {

            var result = _publisherService.GetPublisherBook(publisherId);

            if (!result.Success)
            {
                return new Result<GetPublisherBooksViewModel>(result.Success, result.Message, result.Data);
            }

            return new Result<GetPublisherBooksViewModel>(true, string.Format("{0}", result.Message), result.Data);
        }
    }
}
