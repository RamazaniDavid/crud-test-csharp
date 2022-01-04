using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query;
using Mc2.CrudTest.Service.Services;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Handlers.Customer
{
    public class GetCustomerByIdQueryHandler: IRequestHandler<GetCustomerByIdQuery, CustomerListItemDto>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerListItemDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {

            var model = await _customerService.GetCustomerByIdAsync(request.Id);


            return model;
        }
    }
}
