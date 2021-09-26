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
    public class PublisherService : IPublisherService
    {
        private IPublisherDal _publisherDal;

        public PublisherService(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public IResult<GetPublisherBooksViewModel> GetPublisherBook(Guid publisherId)
        {
            try
            {
                var result = _publisherDal.GetPublisherBook(publisherId);

                if (result.Success)
                {
                    return new Result<GetPublisherBooksViewModel>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<GetPublisherBooksViewModel>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<GetPublisherBooksViewModel>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }

        public IResult<List<Publisher>> GetPublishers()
        {
            try
            {
                var result = _publisherDal.GetPublishers();

                if (result.Success)
                {
                    return new Result<List<Publisher>>(true, Messages.Successful, result.Data);
                }
                else
                {
                    return new Result<List<Publisher>>(false, Messages.Unsuccessful, result.Data);
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Publisher>>(false, string.Format("{0} {1}", Messages.Unsuccessful, ex.Message), null);
            }
        }
    }
}