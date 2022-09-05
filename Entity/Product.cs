using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Comment { get; set; }
        public string? Image { get; set; }
        public string? Key { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public int? SListId { get; set; }
        public SList SList { get; set; }

        public virtual Category Category { get; set; }
    }
}
