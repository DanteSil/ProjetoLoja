using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Models;

namespace ProjetoLoja.DataBase.Mappings
{
    public partial class CartMap : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

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

            builder.Property(x => x.CreatedAt)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder
                .HasMany(x => x.Products)
                .WithMany(x => x.Carts)
                .UsingEntity<Dictionary<string, object>>(
                    "CartXProduct",
                    product => product
                        .HasOne<Product>()
                        .WithMany()
                        .HasForeignKey("Fk_ProductId")
                        .HasConstraintName("Fk_CartXProduct_ProductId")
                        .OnDelete(DeleteBehavior.Cascade),
                    cart => cart
                        .HasOne<Cart>()
                        .WithMany()
                        .HasForeignKey("Fk_CartId")
                        .HasConstraintName("Fk_CartXProduct_CartId")
                        .OnDelete(DeleteBehavior.Cascade));

            builder.HasOne(x => x.User)
                .WithMany(x => x.Carts)
                .HasForeignKey(x => x.Fk_UserId)
                .HasConstraintName("Fk_CartXUser")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
