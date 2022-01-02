using Mc2.CrudTest.Core.Caching;
using Mc2.CrudTest.Core.Domian;
using Mc2.CrudTest.Data;
using Mc2.CrudTest.Service.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;

namespace Mc2.CrudTest.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repositoryCustomer = null;

        public CustomerService(IRepository<Customer> repositoryCustomer)
        {
            _repositoryCustomer = repositoryCustomer;

        }

        public async Task<IEnumerable<CustomerListItemDTO>> getCustomersAsync()
        {
            return await _repositoryCustomer.TableNoTracking
          .Select(p => new CustomerListItemDTO
          {
              ID = p.ID,
              BankAccountNumber = p.BankAccountNumber,
              Email = p.Email,
              PhoneNumber = p.CountryCode + "-" + p.PhoneNumber,
              FirstName = p.FirstName,
              LastName = p.LastName,
              BirthDate = p.DateOfBirth.ToShortDateString(),
          }).ToListAsync();

        }


        public async Task<CustomerListItemDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _repositoryCustomer.GetByIdAsync(id);

            return customer.TODTO<CustomerListItemDTO>();
        }

        public async Task<bool> IsExistsCustomerAsync(int id)
        {
            var customer = await _repositoryCustomer.GetByIdAsNoTrackingAsync(id);
            if (customer == null)
                return false;

            return true;
        }

        public async Task<CustomerDTO> RegisterCustomerAsync(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
                throw new ArgumentNullException(nameof(customerDTO));

            var customer = customerDTO.ToEntity<Customer>();
            await _repositoryCustomer.InsertAsync(customer);
            customerDTO.ID = customer.ID;

            return customerDTO;
        }

        public async Task RemoveCustomerAsync(int id)
        {
            var customer = _repositoryCustomer.GetById(id);
            await _repositoryCustomer.DeleteAsync(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
                throw new ArgumentNullException(nameof(customerDTO));

            var customer = _repositoryCustomer.GetById(customerDTO.ID);

            customer.FirstName = customerDTO.FirstName;
            customer.LastName = customerDTO.LastName;
            customer.PhoneNumber = customerDTO.PhoneNumber;
            customer.Email = customerDTO.Email;
            customer.DateOfBirth = customerDTO.DateOfBirth;


            await _repositoryCustomer.UpdateAsync(customer);
        }
    }
}
