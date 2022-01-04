using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;
using Mc2.CrudTest.Core.Caching;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query;
using Mc2.CrudTest.Service.Services;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Handlers.Customer
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerListItemDto>>
    {
        private readonly ICustomerService _customerService;
        private readonly ICacheManager _cacheManager;
        public GetCustomersQueryHandler(ICustomerService customerService, ICacheManager cacheManager)
        {
            _customerService = customerService;
            _cacheManager = cacheManager;
        }

        public async Task<IEnumerable<CustomerListItemDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _cacheManager.GetAsync("ProductSearchKey",
                1000 * 60,
                async () => await _customerService.GetCustomersAsync());
              
            return customers;
        }
    }
}
