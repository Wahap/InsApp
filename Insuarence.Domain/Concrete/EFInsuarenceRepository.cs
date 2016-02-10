using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

using Insuarence.Domain.Abstract;
using Insuarence.Domain.Entities;


namespace Insuarence.Domain.Concrete
{

    public class EFInsuarenceRepository : IInsuarenceRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        Customer IInsuarenceRepository.Find(int id)
        {
            return context.Customers.Find(id);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Add(Customer cst)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer cst)
        {
            throw new NotImplementedException();
        }

    }
}