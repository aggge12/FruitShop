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
using FruitWebService.Models;

namespace FruitWebService.Controllers
{
    public class SuppliersController : ApiController
    {
        private FruitDBModels db = new FruitDBModels();

        // GET: api/Suppliers
        public IQueryable<Supplier> GetSupplier()
        {
            return db.Supplier;
        }

        // GET: api/Suppliers/5
        [ResponseType(typeof(ReturnModels.Supplier))]
        public IHttpActionResult GetSupplier(int id)
        {
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            ReturnModels.Supplier returnSupplier = new ReturnModels.Supplier(supplier.id, supplier.Name);
            return Ok(returnSupplier);
        }

        // PUT: api/Suppliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(int id, Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier.id)
            {
                return BadRequest();
            }

            db.Entry(supplier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Suppliers/PostSupplier
        [ResponseType(typeof(ReturnModels.Supplier))]
        public IHttpActionResult PostSupplier(ReturnModels.Supplier supplier)
        {
            if (supplier.Name == null || supplier.Name == "")
            {
                return BadRequest(ModelState);
            }

            Supplier DBSupplier = new Supplier(supplier.Name);

            db.Supplier.Add(new Supplier(supplier.Name));
            db.SaveChanges();

            ReturnModels.Supplier returnsupplier = new ReturnModels.Supplier(DBSupplier.id, DBSupplier.Name);
            return Ok(returnsupplier);
        }

        // DELETE: api/Suppliers/5
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult DeleteSupplier(int id)
        {
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            db.Supplier.Remove(supplier);
            db.SaveChanges();

            return Ok(supplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierExists(int id)
        {
            return db.Supplier.Count(e => e.id == id) > 0;
        }
    }
}