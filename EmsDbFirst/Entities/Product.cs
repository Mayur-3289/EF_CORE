using System;
using System.Collections.Generic;

#nullable disable

namespace EmsDbFirst.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
