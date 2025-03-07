using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Interfaces.Repositories
{
	public interface IDapperRepository
	{
		Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
		Task<int> ExecuteNonSPAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
		Task<List<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default) where T : class;
		Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default) where T : class;
		Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default) where T : class;
		Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
	}
}
