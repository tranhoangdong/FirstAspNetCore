using eShopSolution.Data.Emtyties;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Product
        {
            public int Id { set; get; }
            public string ProductName { set; get; }
            public decimal? Price { set; get; }
            public decimal? OriginalPrice { set; get; }
            public int? Stock { set; get; }
            public int? ViewCount { set; get; }
            public DateTime? DateCreated { set; get; }

            public bool? IsFeatured { get; set; }
             public string Description { get; set; }
            public int? CategoryId { get; set; }
        

        public Category Category { get; set; }
    }
}