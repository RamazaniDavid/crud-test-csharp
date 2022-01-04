using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Command;
using Mc2.CrudTest.Service.Services;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Handlers.Customer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerDto>
    {
        private readonly ICustomerService _customerService;

        public AddCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDto> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
        
           var model= await _customerService.RegisterCustomerAsync(request.Model);
            return model;   
        }
    }
}
