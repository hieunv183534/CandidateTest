using CandidateTest.Core.Entities;
using CandidateTest.Core.Enums;
using CandidateTest.Core.Interfaces.IRepositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CandidateTest.Infrastructure.Repositories
{
    public class QuestionRepository : BaseRepository<Question>,  IQuestionRepository
    {
        public QuestionRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public object GetQuestions(int index, int count, QuestionTypeEnum type, QuestionCategoryEnum category)
        {
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@QuestionType", type);
                parameters.Add("@QuestionCategory", category);
                parameters.Add("@Indexx", index);
                parameters.Add("@Count", count);
                parameters.Add("Total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var procName = $"Proc_GetQuestions";

                var questions = dbConnection.Query<Question>(procName, param: parameters, commandType: CommandType.StoredProcedure);
                var total = parameters.Get<int>("Total");
                return new
                {
                    total = total,
                    data = questions
                };
            }
        }
    }
}
