using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Insuarence.Domain.Abstract;
using Insuarence.Domain.Entities;
using Insuarence.Domain.Concrete;

namespace Insuarance.WebUI.Controllers
{
    public class CustomerApiController : ApiController
    {

         private IInsuarenceRepository  db;


         public CustomerApiController(IInsuarenceRepository insuarenceRepository)
         {
             this.db = insuarenceRepository;
        }
         // GET api/Default1
         public IEnumerable<Customer> GetCustomers()
         {
             return db.Customers.AsEnumerable();
         }

         // GET api/Default1/5
         public Customer GetCustomers(int id)
         {
             Customer customers = db.Find(id);
             if (customers == null)
             {
                 throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
             }

             return customers;
         }

         // PUT api/Default1/5
         public HttpResponseMessage PutCustomers(int id, Customer customers)
         {
             if (!ModelState.IsValid)
             {
                 return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
             }

             if (id != customers.IdCustomer)
             {
                 return Request.CreateResponse(HttpStatusCode.BadRequest);
             }

             try
             {
                 db.SaveChanges();
             }
             catch (DbUpdateConcurrencyException ex)
             {
                 return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         }

         // POST api/Default1
         public HttpResponseMessage PostCustomers(Customer customers)
         {
             if (ModelState.IsValid)
             {
                 db.Add(customers);
                 db.SaveChanges();

                 HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customers);
                 response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customers.IdCustomer }));
                 return response;
             }
             else
             {
                 return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
             }
         }

         // DELETE api/Default1/5
         public HttpResponseMessage DeleteCustomers(int id)
         {
             Customer customers = db.Find(id);
             if (customers == null)
             {
                 return Request.CreateResponse(HttpStatusCode.NotFound);
             }

             db.Remove(customers);

             try
             {
                 db.SaveChanges();
             }
             catch (DbUpdateConcurrencyException ex)
             {
                 return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
             }

             return Request.CreateResponse(HttpStatusCode.OK, customers);
         }

      
    }
}