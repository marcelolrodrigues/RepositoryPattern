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
            Customer customer = _mapper.Map<Customer>(customerDto);
            Customer outputCustomer = await _customerRepository.Create(customer);
            return outputCustomer;
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            Customer? customer = await _customerRepository.GetById(customerId);
            Customer outputCustomer = customer ?? new Customer("default", "default", "default");
            return outputCustomer;
        }
    }
}
