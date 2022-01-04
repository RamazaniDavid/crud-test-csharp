using System.Collections.Generic;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;

namespace Mc2.CrudTest.Service.Services
{
    public interface ICustomerService
    {
    
        Task<CustomerDto> RegisterCustomerAsync(CustomerDto customerDto);
        Task RemoveCustomerAsync(int id);
        Task<IEnumerable<CustomerListItemDto>> GetCustomersAsync();
        
        Task<CustomerListItemDto> GetCustomerByIdAsync(int id);
        Task UpdateCustomerAsync(CustomerDto customerDto);
        Task<bool> IsExistsCustomerAsync(int id);
    }
}