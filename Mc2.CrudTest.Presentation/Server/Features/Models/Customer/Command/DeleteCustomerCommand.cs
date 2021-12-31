
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Command
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int ID { get; set; }
    }
}
