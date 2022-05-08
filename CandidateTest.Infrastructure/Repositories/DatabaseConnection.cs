using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CandidateTest.Infrastructure.Repositories
{
    public class DatabaseConnection
    {

        private readonly string _connectionString;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Khởi tạo đối tương connector
        /// </summary>
        public IDbConnection DbConnection
        {
            get { return new MySqlConnection(_connectionString); }
        }
    }
}
