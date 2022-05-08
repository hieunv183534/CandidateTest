using CandidateTest.Core.Interfaces.IRepositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CandidateTest.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Declare

        string _tableName;
        string _connectionString;

        #endregion

        #region Consrtuctor

        public BaseRepository(IConfiguration configuration)
        {
            _tableName = typeof(TEntity).Name;
            _connectionString = configuration.GetConnectionString("defaultDb");
        }

        #endregion

        public int Add(TEntity entity)
        {
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                var props = entity.GetType().GetProperties();
                DynamicParameters parameters = new DynamicParameters();
                foreach (var prop in props)
                {
                    var propName = prop.Name;
                    var propValue = prop.GetValue(entity);
                    parameters.Add($"@{propName}", propValue);
                }
                var procName = $"Proc_Insert{_tableName}";
                var rowAffect = dbConnection.Execute(procName, param: parameters, commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
        }

        public int Delete(Guid entityId)
        {
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                var procName = $"Proc_Delete{_tableName}ById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{_tableName}Id", entityId);
                var rowAffect = dbConnection.Execute(procName, param: parameters, commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
        }

        public int DeleteByProp(string propName, object propValue)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{propName}", propValue.ToString());
            var sql = $"delete from {_tableName} where {propName} = @{propName} ";
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                var rowAffect = dbConnection.Execute(sql, param: parameters);
                return rowAffect;
            }
        }

        public List<TEntity> GetAll()
        {
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                var procName = $"Proc_GetAll{_tableName}";
                var entities = dbConnection.Query<TEntity>(procName, commandType: CommandType.StoredProcedure);
                return (List<TEntity>)entities;
            }
        }

        public TEntity GetById(Guid entityId)
        {
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                var procName = $"Proc_Get{_tableName}ById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{_tableName}Id", entityId);
                var entity = dbConnection.QueryFirstOrDefault<TEntity>(procName, param: parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public TEntity GetByProp(string propName, object propValue)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{propName}", propValue.ToString());
            var sql = $"select * from `{_tableName}` where {propName} = @{propName} ";
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                var entity = dbConnection.QueryFirstOrDefault<TEntity>(sql, param: parameters);
                return entity;
            }
        }

        public int Update(TEntity entity, Guid entityId)
        {
            using (var dbConnection = new DatabaseConnection(_connectionString).DbConnection)
            {
                var props = entity.GetType().GetProperties();
                DynamicParameters parameters = new DynamicParameters();
                foreach (var prop in props)
                {
                    var propName = prop.Name;
                    var propValue = prop.GetValue(entity);
                    if (propName == $"{_tableName}Id")
                    {
                        propValue = entityId;
                    }
                    parameters.Add($"@{propName}", propValue);
                }
                var procName = $"Proc_Update{_tableName}";
                var rowAffect = dbConnection.Execute(procName, param: parameters, commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
        }
    }
}
