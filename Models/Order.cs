namespace ProjetoLoja.Models
{
    public class Order
    {
        public int Pk_Id { get; set; }
        public Double TotalAmount { get; set; }
        public Guid Fk_UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string OrderState { get; set; }
        public string PaymentMethod { get; set; }
    }
}
