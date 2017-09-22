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
        public IHttpActionResult PutFruit(int id, ReturnModels.Fruit fruit)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            if (id != fruit.id)
            {
                return BadRequest();
            }

            Fruit DBFruit = db.Fruit.Find(id);
            DBFruit.Name = fruit.Name;
            DBFruit.QuantityInSupply = fruit.QuantityInSupply;

            db.Entry(DBFruit).State = EntityState.Modified;

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

        // POST: /Fruits/PostFruit
        [ResponseType(typeof(ReturnModels.Fruit))]
        public IHttpActionResult PostFruit(ReturnModels.Fruit fruit)
        {
            if (fruit.Name == null || fruit.Name == "")
            {
                return BadRequest(ModelState);
            }
            Fruit DBFruit = new Fruit(fruit.Name, fruit.QuantityInSupply);
            db.Fruit.Add(DBFruit);
            db.SaveChanges();

            ReturnModels.Fruit returnFruit = new ReturnModels.Fruit(DBFruit.id, DBFruit.Name, DBFruit.QuantityInSupply);
            return Ok(returnFruit);
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