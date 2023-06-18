using API.Models;
using API.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using SpecificationPatternRepository.Core;
using System.Linq.Expressions;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("asdasdasddas");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
            Customer outputCustomer = await _customerService.Create(customerDto);
            return Ok(outputCustomer);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int customerId)
        {
            Customer outputCustomer = await _customerService.GetByIdAsync(customerId);
            return Ok(outputCustomer);
        }

        [HttpGet]
        public async Task<IActionResult> ListWithSpecification()
        {
            BaseSpecification<Customer> spec = new BaseSpecification<Customer>();
            Expression<Func<Customer, IEnumerable<Store>>> asd = x => x.Stores;
            spec.SpecificationBuilder
                .Where(x => x.Name == "marcelo")
                //.Include(
                //    new IncludeClause(
                //        asd, 
                //        typeof(Customer), 
                //        typeof(IEnumerable<Store>), 
                //        IncludeTypeEnum.Include
                //    )
                //)
                .OrderBy(cust => cust.Name)
                .ThenByDescending(cust => cust.Address);
            List<Customer> outputCustomer = await _customerService.FindWithSpecification(spec);
            return Ok(outputCustomer);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<Customer> customers = await _customerService.ListAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            Customer outputCustomer = await _customerService.UpdateAsync(customerDto);
            return Ok(outputCustomer);
        }
    }
}
