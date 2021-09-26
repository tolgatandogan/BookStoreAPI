using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Concrete
{
    [Table("FormatType", Schema = "dbo")]
    public class FormatType : EntityBase
    {
        public int FormatId { get; set; }
        public string Name { get; set; }
    }
}