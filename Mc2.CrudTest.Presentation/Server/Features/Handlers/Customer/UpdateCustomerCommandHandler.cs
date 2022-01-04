using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Command;
using Mc2.CrudTest.Service.Services;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Handlers.Customer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerService.UpdateCustomerAsync(request.Model);
            return request.Model;   
        }
    }
}
