using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Insuarence.Domain.Entities;

namespace Insuarence.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

    }

    
}