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
    }
}
