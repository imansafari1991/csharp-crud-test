using AutoMapper;
using Csharp.CRUD.Application.DTOs.Customers;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using Csharp.CRUD.Application.Features.Customers.Requests.Queries;
using Csharp.CRUD.Application.Responses.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Csharp.CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetCustomersQuery();

            return Ok(await _mediator.Send(query));

        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetCustomerByIdQuery() { Id = id };
            var res = await _mediator.Send(query);
            if (res.Success)
            {
                return Ok(res);
            }

            return NotFound(res);


        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerDto dto)
        {
            var command = new CreateCustomerCommand
            {
                CreateCustomerDto = dto
            };

            var res = await _mediator.Send(command);
            if (res.Success)
            {
                return Ok(res);
            }
            else if (res.StatusCode == "404")
            {
                return NotFound(res);
            }
            else
            {
                return BadRequest(res);
            }



        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCustomerDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Query Id and dto Id must have same value.");
            }

            var command = new UpdateCustomerCommand
            {
                UpdateCustomerDto = dto
            };
            var res = await _mediator.Send(command);
            if (res.Success)
            {
                return Ok(res);
            }
            else if (res.StatusCode == "404")
            {
                return NotFound(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var res = await _mediator.Send(command);
            if (res.Success)
            {
                return Ok(res);
            }

            return NotFound(res);




        }
    }
}
