using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Insuarence.Domain.Entities;

namespace Insuarence.Domain.Abstract
{
    public interface IInsuarenceRepository
    {

        IEnumerable<Customer> Customers { get; }
        Customer Find(int id);
        void SaveChanges();
        void Add(Customer cst);
        void Remove(Customer cst);

        //bool Add(Customer entity);
        //bool Add(Quote entity);
        //bool Any(string pass, string userName);



    }


}