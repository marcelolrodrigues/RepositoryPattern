using API.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace API.Services
{
    public class CustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
        }

        public async Task<Customer> Create(CustomerDto customerDto)
        {
            Customer inputCustomer = _mapper.Map<Customer>(customerDto);
            Customer outputCustomer = await _customerRepository.CreateAsync(inputCustomer);
            return outputCustomer;
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            Customer? customer = await _customerRepository.GetByIdAsync(customerId);
            Customer outputCustomer = customer ?? new Customer("default", "default", "default");
            return outputCustomer;
        }

        public async Task<Customer> UpdateAsync(CustomerDto costumerDto)
        {
            Customer inputCustomer = _mapper.Map<Customer>(costumerDto);
            Customer outputCustomer = await _customerRepository.UpdateAsync(inputCustomer);
            return outputCustomer;
        }
    }
}
