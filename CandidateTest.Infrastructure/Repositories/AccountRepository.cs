using CandidateTest.Core.Entities;
using CandidateTest.Core.Interfaces.IRepositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CandidateTest.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public object GetAccounts(int index, int count, string searchTerms, string role)
        {
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SearchTerms", searchTerms);
                parameters.Add("@Role", role);
                parameters.Add("@Indexx", index);
                parameters.Add("@Count", count);
                parameters.Add("Total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var procName = $"Proc_GetAccounts";

                var accounts = dbConnection.Query<Account>(procName, param: parameters, commandType: CommandType.StoredProcedure);
                var total = parameters.Get<int>("Total");
                return new
                {
                    total = total,
                    data = accounts
                };
            }
        }
    }
}
