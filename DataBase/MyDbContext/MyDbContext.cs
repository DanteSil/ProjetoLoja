using Microsoft.EntityFrameworkCore;

namespace ProjetoLoja.DataBase.MyDbContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
