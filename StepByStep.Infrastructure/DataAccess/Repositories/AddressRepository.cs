using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepByStep.Application.Repositories;
using StepByStep.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StepByStep.Infrastructure.DataAccess.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IMapper mapper;

        public AddressRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public bool Add(Address address)
        {
            using var context = new Context();
            var addressEntity = mapper.Map<Entities.Address>(address);

            context.Address.Add(addressEntity);
            var i = context.SaveChanges();

            return i > 0;
        }
        
        public bool Update(Address address)
        {
            using var context = new Context();
            var addressEntity = mapper.Map<Entities.Address>(address);

            context.Address.Update(addressEntity);

            var i = context.SaveChanges();

            return i > 0;
        }


        public Address GetById(Guid id)
        {
            using var context = new Context();

            var address = context.Address
                .Where(w => w.Id == id)
                .Include(s => s.Customer).FirstOrDefault();
                

            return mapper.Map<Address>(address);
        }

        public List<Address> GetAll()
        {
            using var context = new Context();
            var address = context.Address.Include(s => s.Customer).ToList();

            return mapper.Map<List<Address>>(address);
        }

        public bool Delete(Address address)
        {
            using var context = new Context();

            var remover = context.Address.Where(w => w.Id == address.Id).FirstOrDefault();

            context.Address.Remove(remover);

            var i = context.SaveChanges();

            return i > 0;
        }

    }
}
