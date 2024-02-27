using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Models;

namespace ProjetoLoja.DataBase.Mappings
{
    public partial class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Pk_Id);

            builder.Property(x => x.Pk_Id)   
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("REAL")
                .IsRequired();

            builder.Property(x => x.Color)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME")
                .IsRequired();
        }
    }
}
