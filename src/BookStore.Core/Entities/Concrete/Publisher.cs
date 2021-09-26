using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Concrete
{
    [Table("Publisher", Schema = "dbo")]
    public class Publisher : EntityBase
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}