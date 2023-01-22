using API.Models;
using Core.Entities;
using Infrastructure.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Infrastructure;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly BaseRepository<Customer> SampleRepository;

        public CustomerController(SampleRepository<Customer> sampleRepository)
        {
            this.SampleRepository = sampleRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("asdasdasddas");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
            Customer customer = new Customer(
                "Marcelo", "lrodrigues.marcelo@gmail.com", "rua teste 123"
            );
            Customer outputCustomer = await SampleRepository.Create(customer);

            return Ok(outputCustomer);
        }

    }
}
