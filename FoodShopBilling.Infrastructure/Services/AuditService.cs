using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using FoodShopBilling.Application.Extensions;
using FoodShopBilling.Application.Interfaces;
using FoodShopBilling.Application.Interfaces.Services;
using FoodShopBilling.Infra.Infrastructure.Specifications;
using FoodShopBilling.Infrastructure.Contexts;
using FoodShopBilling.Infrastructure.Models.Audit;
using FoodShopBilling.Infrastructure.Models.Identity;
using FoodShopBilling.Infrastructure.Specifications;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests;
using FoodShopBilling.Utilities.Responses.Audit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Linq.Expressions;

namespace FoodShopBilling.Infrastructure.Services
{
	public class AuditService : IAuditService
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IExcelService _excelService;
		private readonly IStringLocalizer<AuditService> _localizer;

		public AuditService(
			IMapper mapper,
			ApplicationDbContext context,
			IExcelService excelService,
			IStringLocalizer<AuditService> localizer)
		{
			_mapper = mapper;
			_context = context;
			_excelService = excelService;
			_localizer = localizer;
		}

        public async Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserProfileTrailsAsync(string userId)
        {
            List<Audit> trails = await _context.AuditTrails.Where(a => a.UserId == userId).OrderByDescending(a => a.Id).Take(6).ToListAsync();
            List<AuditResponse> mappedLogs = _mapper.Map<List<AuditResponse>>(trails);
            return await Result<IEnumerable<AuditResponse>>.SuccessAsync(mappedLogs);
        }

        public async Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId)
		{
			List<Audit> trails = await _context.AuditTrails.Where(a => a.UserId == userId).OrderByDescending(a => a.Id).Take(250).ToListAsync();
			List<AuditResponse> mappedLogs = _mapper.Map<List<AuditResponse>>(trails);
			return await Result<IEnumerable<AuditResponse>>.SuccessAsync(mappedLogs);
		}

		public async Task<IResult<string>> ExportToExcelAsync(string userId, string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false)
		{
			AuditFilterSpecification auditSpec = new(userId, searchString, searchInOldValues, searchInNewValues);
			List<Audit> trails = await _context.AuditTrails
				.Specify(auditSpec)
				.OrderByDescending(a => a.DateTime)
				.ToListAsync();
			string data = await _excelService.ExportAsync(trails, sheetName: _localizer["Audit trails"],
				mappers: new Dictionary<string, Func<Audit, object>>
				{
					{ _localizer["Table Name"], item => item.TableName },
					{ _localizer["Type"], item => item.Type },
					{ _localizer["Date Time (Local)"], item => DateTime.SpecifyKind(item.DateTime, DateTimeKind.Utc).ToLocalTime().ToString("G", CultureInfo.CurrentCulture) },
					{ _localizer["Date Time (UTC)"], item => item.DateTime.ToString("G", CultureInfo.CurrentCulture) },
					{ _localizer["Primary Key"], item => item.PrimaryKey },
					{ _localizer["Old Values"], item => item.OldValues },
					{ _localizer["New Values"], item => item.NewValues },
				});

			return await Result<string>.SuccessAsync(data: data);
		}

		public async Task<DataTablesJsonResult> GetPaginatedAsync(IDataTablesRequest request)
		{
			var rows = _context.AuditTrails.AsQueryable();
			Expression<Func<Audit, AuditResponse>> expression = e => new AuditResponse
			{
				Id = e.Id,
				UserId = e.UserId,
				AffectedColumns = e.AffectedColumns,
				DateTime = e.DateTime,
				NewValues = e.NewValues,
				OldValues = e.OldValues,
				PrimaryKey = e.PrimaryKey,
				TableName = e.TableName,
				Type = e.Type
			};
			AuditFilterSpecification locationFilter = new(request.Search.Value);
			var filteredRows = rows.AsNoTracking()
				   .Specify(locationFilter).Select(expression);

			// Ordering and Paging
			var pagedRows = filteredRows
				.SortBy(request.Columns)
				.Skip(request.Start)
				.Take(request.Length);

			var response = DataTablesResponse.Create(request, rows.Count(),
				filteredRows.Count(), pagedRows);

			return new DataTablesJsonResult(response);
		}

        public async Task<PaginatedResult<AuditResponse>> GetAuditPaginated(AuditPagedRequest request)
        {
            Expression<Func<Audit, AuditResponse>> expression = e => new AuditResponse
            {

                Id = e.Id,
                UserId = e.UserId!,
                TableName = e.TableName,
                Type = e.Type,
                AffectedColumns = e.AffectedColumns!,
                DateTime = e.DateTime,
                NewValues = e.NewValues!,
                OldValues = e.OldValues!,
                PrimaryKey = e.PrimaryKey!
            };
            // Convert them into view models
            var rows = _context.AuditTrails;

            AuditFilterSpecification locationFilter = new(request.SearchString);
            var filteredRows = rows.AsQueryable()
                   .Specify(locationFilter).Select(expression);

            // Ordering and Paging
            var pagedRows = await filteredRows
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return pagedRows;
        }
    }
}
