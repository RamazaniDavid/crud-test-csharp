
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Command;
using Mc2.CrudTest.Service.Catalog;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;

namespace Mc2.CrudTest.Presentation.Server.Customer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerService.UpdateCustomerAsync(request.Model);
            return request.Model;   
        }
    }
}
