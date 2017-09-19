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
    public class FruitSuppliersController : ApiController
    {
        private FruitDBModels db = new FruitDBModels();

        // GET: api/FruitSuppliers
        public IQueryable<FruitSupplier> GetFruitSupplier()
        {
            return db.FruitSupplier;
        }

        // GET: api/FruitSuppliers/5
        [ResponseType(typeof(FruitSupplier))]
        public IHttpActionResult GetFruitSupplier(int id)
        {
            FruitSupplier fruitSupplier = db.FruitSupplier.Find(id);
            if (fruitSupplier == null)
            {
                return NotFound();
            }

            return Ok(fruitSupplier);
        }

        // GET: api/GetFruitSupplierByFruit/5
        [ResponseType(typeof(ReturnModels.FruitSupplier))]
        public IHttpActionResult GetFruitSupplierByFruit(int id)
        {
            var fruitSuppliers =
            from fruitsupp in db.FruitSupplier
            where fruitsupp.Fruit == id
            select fruitsupp;

            if (fruitSuppliers == null)
            {
                return NotFound();
            }

            FruitSupplier supp = (FruitSupplier)fruitSuppliers; 
            List<ReturnModels.FruitSupplier> listOfReturnModels = new List<ReturnModels.FruitSupplier>();

            foreach (FruitSupplier suppl in fruitSuppliers)
            {
                listOfReturnModels.Add(new ReturnModels.FruitSupplier(suppl.id, suppl.Fruit, suppl.Supplier));
            }

            return Ok(listOfReturnModels);
        }

        // PUT: api/FruitSuppliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFruitSupplier(int id, FruitSupplier fruitSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fruitSupplier.id)
            {
                return BadRequest();
            }

            db.Entry(fruitSupplier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FruitSupplierExists(id))
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

        // POST: api/FruitSuppliers
        [ResponseType(typeof(FruitSupplier))]
        public IHttpActionResult PostFruitSupplier(FruitSupplier fruitSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FruitSupplier.Add(fruitSupplier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fruitSupplier.id }, fruitSupplier);
        }

        // DELETE: api/FruitSuppliers/5
        [ResponseType(typeof(FruitSupplier))]
        public IHttpActionResult DeleteFruitSupplier(int id)
        {
            FruitSupplier fruitSupplier = db.FruitSupplier.Find(id);
            if (fruitSupplier == null)
            {
                return NotFound();
            }

            db.FruitSupplier.Remove(fruitSupplier);
            db.SaveChanges();

            return Ok(fruitSupplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FruitSupplierExists(int id)
        {
            return db.FruitSupplier.Count(e => e.id == id) > 0;
        }
    }
}