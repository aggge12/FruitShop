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