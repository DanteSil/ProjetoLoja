using Microsoft.Data.Sqlite;
using System.Data;

namespace ProjetoLoja.Repository
{
    public class BaseRepository
    {
        private readonly string connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected IDbConnection connection 
        { 
            get 
            { 
                return new SqliteConnection(connectionString); 
            } 
        }
    }
}
