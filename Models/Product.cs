namespace ProjetoLoja.Models
{
    public class Product
    {
        public int Pk_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
