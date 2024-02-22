using Dapper;
using System.Data;

namespace ProjetoLoja.Repository
{
    public class DapperRepository
    {
        private readonly IDbConnection _db;

        public DapperRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<T> ConsultarDados<T>(string query)
        {
            return _db.Query<T>(query);
        }
    }
}
