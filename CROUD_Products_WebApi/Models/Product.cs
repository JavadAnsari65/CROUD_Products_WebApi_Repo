using static System.Net.Mime.MediaTypeNames;

namespace CROUD_Products_WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } // یک به چند با دسته‌بندی
        public List<Image> Images { get; set; } // چند به چند با تصویر
    }
}
