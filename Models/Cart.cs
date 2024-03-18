namespace ProjetoLoja.Models
{
    public class Cart
    {
        public int Pk_Id { get; set; }
        public Double TotalAmount { get; set; }
        public Guid Fk_UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public bool IsActive { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
