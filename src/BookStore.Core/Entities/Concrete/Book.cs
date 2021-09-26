using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Concrete
{
    [Table("Book", Schema = "dbo")]
    public class Book : EntityBase
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public bool IsValidISBN { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid FormatId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Version { get; set; }
        public string Preface { get; set; }
        public int QuantityLeft { get; set; }
        public int WarehouseLocation { get; set; }
        public DateTime NextStockDate { get; set; }
    }
}