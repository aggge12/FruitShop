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
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult GetSupplier(int id)
        {
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
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

        // POST: api/Suppliers
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult PostSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Supplier.Add(supplier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supplier.id }, supplier);
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