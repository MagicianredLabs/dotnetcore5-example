using it.example.dotnetcore5.domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace it.example.dotnetcore5.dal.dapper.Repositories
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            var databaseType = _configuration.GetSection("DatabaseType").Value;
            if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mysql")
            {
                return new MySqlConnection(_configuration.GetConnectionString("MyBlog_mysql"));
            }
            else if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mssql")
            {
                return new SqlConnection(_configuration.GetConnectionString("MyBlog_mssql"));
            } else
            {
                throw new NotImplementedException();
            }
        }
    }
}
