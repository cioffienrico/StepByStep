using Microsoft.AspNetCore.Mvc;
using StepByStep.Application.UseCases.Add;
using StepByStep.Application.UseCases.GetAll;
using StepByStep.Application.UseCases.GetById;
using StepByStep.Application.UseCases.Update;
using StepByStep.Webapi.Model;
using StepByStep.Webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StepByStep.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAddUseCase addUseCase;
        private readonly IGetAllUseCase getAllUseCase;
        private readonly IGetByIdUseCase getByIdUseCase;
        private readonly UpdateUseCase updateUseCase;
        public CustomerController(IAddUseCase addUseCase, IGetAllUseCase getAllUseCase, IGetByIdUseCase getByIdUseCase, UpdateUseCase updateUseCase)
        {
            this.addUseCase = addUseCase;
            this.getAllUseCase = getAllUseCase;
            this.getByIdUseCase = getByIdUseCase;
            this.updateUseCase = updateUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [Route("Add")]
        public IActionResult AddCustomer([FromBody] AddCustomerModel input)
        {
            var request = new AddRequest(input.Name,
                input.Birthday,
                input.Rg,
                input.Cpf,
                input.Cep,
                input.Road,
                input.Number,
                input.Complement,
                input.Neighborhood,
                input.City,
                input.State);          

            addUseCase.Execute(request);
           
             if (!request.Customer.IsValid)
            {
                return BadRequest(request.Erros);
            }

            return Ok(request.Customer.Id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetCustomerModel>), 200)]
        [Route("GetAll")]

        public IActionResult GetAllCustomer()
        {
            var customers = getAllUseCase.Execute();
            
            var customerModel = customers.Select(s => new GetCustomerModel(s.Id, s.Name, s.Birthday, s.Rg, s.Cpf, s.Address.Cep, s.Address.Road, s.Address.Number, 
                s.Address.Complement, s.Address.Neighborhood, s.Address.City, s.Address.State)).ToList();
            return Ok(customerModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [Route("GetById")]
        public IActionResult GetByIdCustomer([FromBody] GetCustomerIdInput input)
        {                     
            var customer = getByIdUseCase.Execute(new GetByIdRequest(input.CustomerId));

            var customerModel = new GetCustomerModel(customer.Id, customer.Name, customer.Birthday, customer.Rg, customer.Cpf, customer.Address.Cep, customer.Address.Road, customer.Address.Number, customer.Address.Complement, customer.Address.Neighborhood, customer.Address.City, customer.Address.State);

            return Ok(customerModel);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Guid), 200)]
        [Route("Update")]
        public IActionResult UpdateCustomer([FromBody] CustomerUpdateInput updateInput)
        {    
            var update = (new UpdateRequest(updateInput.Id, updateInput.Name, updateInput.Birthday, updateInput.Rg, updateInput.Cpf, updateInput.Cep, updateInput.Road, updateInput.Number, updateInput.Complement, updateInput.Neighborhood, updateInput.City, updateInput.State));

            updateUseCase.Execute(update);

            /*if (!update.Customer.IsValid)
            {
                return BadRequest(update.Erros);
            }*/

            return Ok(update.Id);
        }

    }
}
