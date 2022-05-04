using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CandidateTest.Infrastructure.Repositories
{
    public class DatabaseConnection
    {
        /// <summary>
        /// Khởi tạo đối tương connector
        /// </summary>
        public static IDbConnection DbConnection
        {
            get { return new MySqlConnection("Host=MYSQL8001.site4now.net ;Port=3306 ;Database=db_a86381_pj22 ; User Id=a86381_pj22; Password=pj234567"); }
        }
    }
}
