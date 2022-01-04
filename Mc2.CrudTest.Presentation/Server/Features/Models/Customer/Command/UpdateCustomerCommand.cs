using Mc2.CrudTest.Common.DTOs;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Command
{
    public class UpdateCustomerCommand : IRequest<CustomerDto>
    {
        public CustomerDto Model { get; set; }
      
    }
}
