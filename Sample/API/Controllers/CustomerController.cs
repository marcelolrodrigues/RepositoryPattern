using API.Models;
using API.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

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
