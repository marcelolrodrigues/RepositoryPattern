using Core.Entities;
using Infrastructure;
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

        public IActionResult Index()
        {
            return Ok("asdasdasddas");
        }

        public async Task<IActionResult> Create()
        {
            Customer customer = new Customer(
                "Marcelo", "lrodrigues.marcelo@gmail.com", "rua teste 123"
            );
            Customer outputCustomer = await SampleRepository.Create(customer);

            return Ok(outputCustomer);
        }

    }
}
