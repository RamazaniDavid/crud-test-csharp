using System.Threading.Tasks;
using Mc2.CrudTest.Common.DTOs;
using Mc2.CrudTest.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Command;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{

    public class CustomerController :Mc2CrudTestController
    {


        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]


        public async Task<IActionResult> GetAsync()
        {
            var customers = await _mediator.Send(new GetCustomersQuery());

            return Ok(customers);
        }

        [HttpGet("find/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Find(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery() { Id = id });
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RegisterAsync([FromForm] CustomerDto model)
        {
            if (model.Id != 0)
                return BadRequest();

            model = await _mediator.Send(new AddCustomerCommand() { Model = model });

            return CreatedAtAction("find", new { id = model.Id }, model);

        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAsync([FromForm] CustomerDto model)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery() { Id = model.Id });
            if (customer == null)
                return NotFound();

            await _mediator.Send(new UpdateCustomerCommand() { Model = model });

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveAsync(int id)
        {

            var customer = await _mediator.Send(new GetCustomerByIdQuery() { Id = id });
            if (customer == null)
                return NotFound();

            await _mediator.Send(new DeleteCustomerCommand() { Id = id });

            return Ok();
        }
    }
}