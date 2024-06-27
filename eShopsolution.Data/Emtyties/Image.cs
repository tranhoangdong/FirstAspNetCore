namespace eShopSolution.Data.Entities
{
    public class Image
    {

        public int ID { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public Product product { get; set; }
    }
}