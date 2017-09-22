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

        // GET: GetFruitSuppliersByName
        [ResponseType(typeof(IEnumerable<ReturnModels.FruitSupplier>))]
        public IHttpActionResult GetFruitSuppliersBySupplierName(string name)
        {
            var fruitSuppliers =
            from fruitsupp in db.FruitSupplier
            where fruitsupp.Supplier1.Name == name
            select fruitsupp;

            if (fruitSuppliers == null)
            {
                return NotFound();
            }
            List<ReturnModels.FruitSupplier> returnFruitSuppliers = new List<ReturnModels.FruitSupplier>();
            return Ok(returnFruitSuppliers);
        }

        // GET: api/GetFruitSupplierByFruit/{fruit ID}
        [ResponseType(typeof(ReturnModels.Supplier))]
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

            List<ReturnModels.Supplier> listOfReturnModels = new List<ReturnModels.Supplier>();

            foreach (FruitSupplier suppl in fruitSuppliers)
            {
                listOfReturnModels.Add(new ReturnModels.Supplier(suppl.Supplier1.id,suppl.Supplier1.Name));
            }

            return Ok(listOfReturnModels);
        }

        // GET: api/GetFruitSupplierByFruitAndSupplier/{fruit ID/supplier ID}
        [ResponseType(typeof(ReturnModels.FruitSupplier))]
        [Route("FruitSuppliers/GetFruitSupplierByFruitAndSupplier/{FruitId}/{SupplierId}")]
        public IHttpActionResult GetFruitSupplierByFruitAndSupplier(int FruitId, int SupplierId)
        {
            var fruitSuppliers =
            (from fruitsupp in db.FruitSupplier
            where fruitsupp.Fruit == FruitId && fruitsupp.Supplier == SupplierId
            select fruitsupp).FirstOrDefault();

            if (fruitSuppliers == null)
            {
                return NotFound();
            }
            FruitSupplier f = fruitSuppliers;

            ReturnModels.FruitSupplier returnSupplier = new ReturnModels.FruitSupplier(f.id,f.Fruit,f.Supplier);

            return Ok(returnSupplier);
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

        // POST: api/FruitSuppliers/PostFruitSupplier
        [ResponseType(typeof(ReturnModels.FruitSupplier))]
        public IHttpActionResult PostFruitSupplier(ReturnModels.FruitSupplier fruitSupplier)
        {
            FruitSupplier DBFruitSupplier = new FruitSupplier(fruitSupplier.Fruit, fruitSupplier.Supplier);

            var check = from f in db.FruitSupplier
                        where f.Fruit == fruitSupplier.Fruit && f.Supplier == fruitSupplier.Supplier
                        select f;
            if (check.Any())
            {
                return NotFound();
            }

            db.FruitSupplier.Add(DBFruitSupplier);
            db.SaveChanges();

           

            return Ok(new ReturnModels.FruitSupplier(DBFruitSupplier.id, DBFruitSupplier.Fruit,DBFruitSupplier.Supplier));
        }


        // DELETE: api/FruitSuppliers/DeleteFruitSupplier/5
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