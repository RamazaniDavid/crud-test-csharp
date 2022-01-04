using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;
using Mc2.CrudTest.Core.Domain;
using Mc2.CrudTest.Data;
using Mc2.CrudTest.Service.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repositoryCustomer;

        public CustomerService(IRepository<Customer> repositoryCustomer)
        {
            _repositoryCustomer = repositoryCustomer;

        }

        public async Task<IEnumerable<CustomerListItemDto>> GetCustomersAsync()
        {
            return await _repositoryCustomer.TableNoTracking
          .Select(p => new CustomerListItemDto
          {
              Id = p.Id,
              BankAccountNumber = p.BankAccountNumber,
              Email = p.Email,
              PhoneNumber = p.CountryCode + "-" + p.PhoneNumber,
              FirstName = p.FirstName,
              LastName = p.LastName,
              BirthDate = p.DateOfBirth.ToShortDateString(),
          }).ToListAsync();

        }

        public async Task<CustomerListItemDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _repositoryCustomer.GetByIdAsync(id);

            return customer.ToDto<CustomerListItemDto>();
        }

        public async Task<bool> IsExistsCustomerAsync(int id)
        {
            var customer = await _repositoryCustomer.GetByIdAsNoTrackingAsync(id);
            if (customer == null)
                return false;

            return true;
        }

        public async Task<CustomerDto> RegisterCustomerAsync(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            var customer = customerDto.ToEntity<Customer>();
            await _repositoryCustomer.InsertAsync(customer);
            customerDto.Id = customer.Id;

            return customerDto;
        }

        public async Task RemoveCustomerAsync(int id)
        {
            var customer = _repositoryCustomer.GetById(id);
            await _repositoryCustomer.DeleteAsync(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            var customer = _repositoryCustomer.GetById(customerDto.Id);

            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Email = customerDto.Email;
            customer.DateOfBirth = customerDto.DateOfBirth;


            await _repositoryCustomer.UpdateAsync(customer);
        }
    }
}
