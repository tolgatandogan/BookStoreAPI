using BookStore.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Concrete
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}