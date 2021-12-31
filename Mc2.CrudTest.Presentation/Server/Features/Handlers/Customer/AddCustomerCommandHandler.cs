
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Command;
using Mc2.CrudTest.Service.Catalog;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;

namespace Mc2.CrudTest.Presentation.Server.Customer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerService _customerService;

        public AddCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDTO> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
        
           var model= await _customerService.RegisterCustomerAsync(request.Model);


            return model;   
        }
    }
}
