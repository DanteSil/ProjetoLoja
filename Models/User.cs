namespace ProjetoLoja.Models
{
    public class User
    {
        public Guid Pk_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool IsAdmin { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
