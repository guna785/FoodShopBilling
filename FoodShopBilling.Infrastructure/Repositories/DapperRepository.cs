using Dapper;
using DataTables.AspNet.AspNetCore;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Shared.Wrapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Infrastructure.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        private IDbConnection connection;
        private readonly IConfiguration _configuration;
        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<List<T>> QuerySPAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default) where T : class
        {
            return (await connection.QueryAsync<T>(sql, param, transaction, null, CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.ExecuteAsync(sql, param, transaction, null, CommandType.StoredProcedure);
        }

        public async Task<int> ExecuteNonSPAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.ExecuteAsync(sql, param, transaction, null);
        }

        public async Task<List<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default) where T : class
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default) where T : class
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default) where T : class
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }
        public async Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.ExecuteReaderAsync(sql, param, transaction);
        }
        public void Dispose()
        {
            connection.Dispose();
        }

        public async Task BackUpDB()
        {
            connection = new SqlConnection(_configuration.GetConnectionString("BackUpConnection"));
        }

        public async Task<IDataReader> ExecuteReaderSpAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.ExecuteReaderAsync(sql, param, transaction, commandType: CommandType.StoredProcedure);
        }
    }
}
