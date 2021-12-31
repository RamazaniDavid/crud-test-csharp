using System.Collections.Generic;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;

namespace Mc2.CrudTest.Service.Catalog
{
    public interface ICustomerService
    {
    
        Task<CustomerDTO> RegisterCustomerAsync(CustomerDTO customerDTO);
        Task RemoveCustomerAsync(int id);
        Task<IEnumerable<CustomerListItemDTO>> getCustomersAsync();
        
        Task<CustomerListItemDTO> GetCustomerByIdAsync(int id);
        Task UpdateCustomerAsync(CustomerDTO customerDTO);
        Task<bool> IsExistsCustomerAsync(int id);
    }
}