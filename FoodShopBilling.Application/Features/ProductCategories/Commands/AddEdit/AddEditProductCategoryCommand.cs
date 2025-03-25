using FoodShopBilling.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Features.ProductCategories.Commands.AddEdit
{
    public class AddEditProductCategoryCommand:IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    internal class AddEditProductCategoryCommandHandler : IRequestHandler<AddEditProductCategoryCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(AddEditProductCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
