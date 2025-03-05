namespace Wardrobe_Bliss.Areas.AdminArea.Models
{
    public class ProductModel
    {
        public int? product_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stock_quantity { get; set; }
        public int category_id { get; set; }
        public string image_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
