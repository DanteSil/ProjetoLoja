using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Models;

namespace ProjetoLoja.DataBase.Mappings
{
    public partial class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Pk_Id);

            builder.Property(x => x.Pk_Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TotalAmount)
                .HasColumnType("REAL")
                .IsRequired();

            builder.Property(x => x.ProductQuantity)
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(x => x.Fk_UserId)
                .HasColumnType("TEXT")
                .IsRequired();            
            
            builder.Property(x => x.PaymentMethod)
                .HasColumnType("VARCHAR")
                .IsRequired();          
            
            builder.Property(x => x.OrderState)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.OrderDate)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder
                .HasMany(x => x.Products)
                .WithMany(x => x.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderXProduct",
                    product => product
                        .HasOne<Product>()
                        .WithMany()
                        .HasForeignKey("Fk_ProductId")
                        .HasConstraintName("Fk_OrderXProduct_ProductId")
                        .OnDelete(DeleteBehavior.Cascade),
                    order => order
                        .HasOne<Order>()
                        .WithMany()
                        .HasForeignKey("Fk_OrderId")
                        .HasConstraintName("Fk_OrderXProduct_OrderId")
                        .OnDelete(DeleteBehavior.Cascade));

            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.Fk_UserId)
                .HasConstraintName("Fk_OrderXUser")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
