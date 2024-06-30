using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class ProductDTO
    {
    
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<ImageDTO> Images { get; set; }
    }
    public class ImageDTO
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
    }
}
