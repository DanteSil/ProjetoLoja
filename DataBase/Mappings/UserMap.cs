using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLoja.Models;

namespace ProjetoLoja.DataBase.Mappings
{
    public partial class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Pk_Id);

            builder.Property(x => x.Pk_Id)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("VARCHAR")
                .IsRequired();
            
            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .IsRequired();          
            
            builder.Property(x => x.Password)
                .HasColumnType("VARCHAR")
                .IsRequired();         
            
            builder.Property(x => x.IsAdmin)
                .HasColumnType("BOOLEAN")
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
