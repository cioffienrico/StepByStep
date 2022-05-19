using StepByStep.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.Repositories
{
    public interface IAddressRepository
    {
        bool Add(Address address);
        bool Update(Address address);
        List<Address> GetAll();
        Address GetById(Guid id);
        bool Delete(Address address);

    }
}
