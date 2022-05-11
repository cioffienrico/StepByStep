using Microsoft.AspNetCore.Mvc;
using StepByStep.Application.UseCases.Add;
using StepByStep.Application.UseCases.GetAll;
using StepByStep.Application.UseCases.GetById;
using StepByStep.Application.UseCases.Update;
using StepByStep.Webapi.Models;
using System;
using System.Collections.Generic;

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

            return Ok(request.Customer.Id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetCustomerModel>), 200)]
        [Route("GetAll")]

        public IActionResult GetAllCustomer()
        {
            var customers = getAllUseCase.Execute();
            var customerModel = new List<GetCustomerModel>();

            for (int i = 0; i < customers.Count; i++)
            {
                customerModel.Add(new GetCustomerModel(customerModel[i].Name, customerModel[i].Birthday, customerModel[i].Rg, customerModel[i].Cpf, customerModel[i].Cep, customerModel[i].Road, customerModel[i].Number, customerModel[i].Complement, customerModel[i].Neighborhood, customerModel[i].City, customerModel[i].State));
            }
            return Ok(customerModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [Route("GetById")]
        public IActionResult GetByIdCustomer([FromBody] GetCustomerIdInput input)
        {                     
            var customer = getByIdUseCase.Execute(new GetByIdRequest(input.CustomerId));

            var customerModel = new GetCustomerModel(customer.Name, customer.Birthday, customer.Rg, customer.Cpf, customer.Adress.Cep, customer.Adress.Road, customer.Adress.Number, customer.Adress.Complement, customer.Adress.Neighborhood, customer.Adress.City, customer.Adress.State);

            return Ok(customerModel);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Guid), 200)]
        [Route("Update")]
        public IActionResult UpdateCustomer([FromBody] GetCustomerIdInput input)
        {
            var customer = getByIdUseCase.Execute(new GetByIdRequest(input.CustomerId));

            var customerModel = updateUseCase.Execute(new UpdateRequest(customer.Id, customer.Name, customer.Birthday, customer.Rg, customer.Cpf, customer.Adress.Cep, customer.Adress.Road, customer.Adress.Number, customer.Adress.Complement, customer.Adress.Neighborhood, customer.Adress.City, customer.Adress.State));

            return Ok(customerModel);
        }

    }
}
