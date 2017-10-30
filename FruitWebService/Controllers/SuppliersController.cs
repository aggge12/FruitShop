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
        private FruitModel db = new FruitModel();

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

        // GET: GetSuppliersByName/{supplier name}
        [ResponseType(typeof(IEnumerable<ReturnModels.Supplier>))]
        [Route("Suppliers/GetSuppliersByName/{name}")]
        public IHttpActionResult GetSuppliersByName(string name)
        {
            var suppliersResult = 
            from s in db.Supplier
            where s.Name.Contains(name)
            select s;

            if (suppliersResult == null)
            {
                return NotFound();
            }
            List<ReturnModels.Supplier> returnSuppliers = new List<ReturnModels.Supplier>();

            foreach (Supplier supplier in suppliersResult)
            {
                returnSuppliers.Add(new ReturnModels.Supplier(supplier.id,supplier.Name));
            }

            return Ok(returnSuppliers);
        }

        // PUT: api/Suppliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(int id, ReturnModels.Supplier supplier)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            if (id != supplier.id)
            {
                return BadRequest();
            }

            Supplier DBSupplier = db.Supplier.Find(id);
            DBSupplier.Name = supplier.Name;

            db.Entry(DBSupplier).State = EntityState.Modified;

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

            db.Supplier.Add(DBSupplier);
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
            var fruitSupplier = from f in db.FruitSupplier
                                where f.Supplier == id
                                select f;

            if (fruitSupplier != null)
            {
                foreach (FruitSupplier fs in fruitSupplier) // cascading delete
                {
                    db.FruitSupplier.Remove(fs);
                }
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