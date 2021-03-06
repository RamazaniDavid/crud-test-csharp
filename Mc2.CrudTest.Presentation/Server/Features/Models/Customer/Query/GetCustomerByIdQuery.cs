using Mc2.CrudTest.Common.DTOs;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query
{
    public class GetCustomerByIdQuery: IRequest<CustomerListItemDto>
    {
        public int Id { get; set; }
    }
}
