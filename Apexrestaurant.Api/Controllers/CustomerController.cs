using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apexrestaurant.Repository.Domain;
using Apexrestaurant.Services.SCustomer;
using Microsoft.AspNetCore.Mvc;

namespace Apexrestaurant.Api.Controllers
{
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Customer model)
        {
            _customerService.Insert(model);
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] Customer model)
        {
            _customerService.Update(model);
            return Ok();
        }
        [HttpDelete]
        [Route("")]
        public IActionResult Delete([FromBody] Customer model)
        {
            _customerService.Delete(model);
            return Ok();
        }
    }

}