using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Command;
using Mc2.CrudTest.Service.Services;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Handlers.Customer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerByIdAsync(request.Id);
            if (customer != null)
            {
                await _customerService.RemoveCustomerAsync(request.Id);

            }

            return true;
        }


    }
}
