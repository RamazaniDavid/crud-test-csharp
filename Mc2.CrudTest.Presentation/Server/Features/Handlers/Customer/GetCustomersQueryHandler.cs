
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Mc2.CrudTest.Common.DTOs;
using Mc2.CrudTest.Service.Customers;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query;
using Mc2.CrudTest.Core.Caching;

namespace Mc2.CrudTest.Presentation.Server.Customer
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerListItemDTO>>
    {
        private readonly ICustomerService _customerService;
        private readonly ICacheManager _cacheManager = null;
        public GetCustomersQueryHandler(ICustomerService customerService, ICacheManager cacheManager)
        {
            _customerService = customerService;
            _cacheManager = cacheManager;
        }

        public async Task<IEnumerable<CustomerListItemDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _cacheManager.GetAsych("ProductSearchKey",1000*60, async () => await _customerService.getCustomersAsync());
              
            return customers;
        }
    }
}
