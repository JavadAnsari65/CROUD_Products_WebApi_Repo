namespace CROUD_Products_WebApi.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; } 

        public int ProductId { get; set; }
        public Product Products { get; set; } // چند به چند با محصول
    }
}
