using MediatR;
using System.Collections.Generic;
using Mc2.CrudTest.Common.DTOs;

namespace Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query
{
    public class GetCustomersQuery: IRequest<IEnumerable<CustomerListItemDTO>>
    {
        
    }
}
