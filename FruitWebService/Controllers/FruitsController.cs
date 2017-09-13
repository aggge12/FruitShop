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
    public class FruitsController : ApiController
    {
        private FruitDBModels db = new FruitDBModels();

        // GET: api/Fruits
        public IQueryable<Fruit> GetFruit()
        {
            return db.Fruit;
        }

        // GET: api/Fruits/5
        [ResponseType(typeof(ReturnModels.Fruit))]
        public IHttpActionResult GetFruit(int id)
        {
            Fruit fruit = db.Fruit.Find(id);
            if (fruit == null)
            {
                return NotFound();
            }

            ReturnModels.Fruit returnFruit = new ReturnModels.Fruit(fruit.id, fruit.Name, fruit.QuantityInSupply);


            return Ok(returnFruit);
        }

        // PUT: api/Fruits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFruit(int id, Fruit fruit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fruit.id)
            {
                return BadRequest();
            }

            db.Entry(fruit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FruitExists(id))
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

        // POST: api/Fruits
        [ResponseType(typeof(Fruit))]
        public IHttpActionResult PostFruit(Fruit fruit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fruit.Add(fruit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fruit.id }, fruit);
        }

        // DELETE: api/Fruits/5
        [ResponseType(typeof(Fruit))]
        public IHttpActionResult DeleteFruit(int id)
        {
            Fruit fruit = db.Fruit.Find(id);
            if (fruit == null)
            {
                return NotFound();
            }

            db.Fruit.Remove(fruit);
            db.SaveChanges();

            return Ok(fruit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FruitExists(int id)
        {
            return db.Fruit.Count(e => e.id == id) > 0;
        }
    }
}