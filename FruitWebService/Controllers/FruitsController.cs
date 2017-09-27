﻿using System;
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
        private FruitModel db = new FruitModel();

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

            ReturnModels.Fruit returnFruit = new ReturnModels.Fruit(fruit.id, fruit.Name, fruit.QuantityInSupply, (int)fruit.Price);

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
            DBFruit.Price = fruit.price;

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

        // POST: /Fruits/PostFruitTransaction
        [ResponseType(typeof(ReturnModels.ProcessedOutgoingTransactions))]
        public IHttpActionResult PostFruitTransaction(List<ReturnModels.ContentOfOutgoingTransaction> transactionContent)
        {
            ProcessedOutgoingTransactions transaction = new ProcessedOutgoingTransactions("pending", DateTime.Now);
            ReturnModels.ProcessedOutgoingTransactions returnTransaction = new ReturnModels.ProcessedOutgoingTransactions();
            try
            {


                db.ProcessedOutgoingTransactions.Add(transaction);
                db.SaveChanges();

                try
                {
                    foreach (ReturnModels.ContentOfOutgoingTransaction transact in transactionContent)
                    {
                        ContentOfOutgoingTransaction transactionItem = new ContentOfOutgoingTransaction(transact.Fruit, transaction.id, transact.Amount);
                        db.ContentOfOutgoingTransaction.Add(transactionItem);
                        
                    }
                    transaction.status = "Transaction Verified";
                    db.SaveChanges();

                }
                catch
                {
                    FruitModel mydb = new FruitModel();
                    ProcessedOutgoingTransactions transactionFailed = mydb.ProcessedOutgoingTransactions.Find(transaction.id);
                    transactionFailed.status = "Transaction Failed";
                    mydb.SaveChanges();
                }
            }
            catch
            {
                return BadRequest();
            }
            returnTransaction = new ReturnModels.ProcessedOutgoingTransactions(transaction.id, transaction.status, (DateTime)transaction.TimeProcessed);
            return Ok(returnTransaction);
        }


        // POST: /Fruits/PostFruit
        [ResponseType(typeof(ReturnModels.Fruit))]
        public IHttpActionResult PostFruit(ReturnModels.Fruit fruit)
        {
            if (fruit.Name == null || fruit.Name == "")
            {
                return BadRequest(ModelState);
            }
            Fruit DBFruit = new Fruit(fruit.Name, fruit.QuantityInSupply, fruit.price);
            db.Fruit.Add(DBFruit);
            db.SaveChanges();

            ReturnModels.Fruit returnFruit = new ReturnModels.Fruit(DBFruit.id, DBFruit.Name, DBFruit.QuantityInSupply,(int)DBFruit.Price);
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