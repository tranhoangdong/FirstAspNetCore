using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class ProductDto
    {
        public int Id { set; get; }
        public string ProductName { set; get; }
        public int CategoryId { set; get; }
        public string Status { set; get; }
    }
}
