using System.Data;

namespace it.example.dotnetcore5.domain.Interfaces.Repositories
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
