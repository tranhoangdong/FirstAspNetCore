using System.Collections.Generic;

namespace eShopSolution.Data.Entities
{
    public class Product
        {

        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public ICollection<Image> Images { get; set; }
    }
}