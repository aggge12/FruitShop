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
    public class ContentOfIncomingTransactionsController : ApiController
    {
        private FruitModel db = new FruitModel();

        // GET: api/ContentOfIncomingTransactions
        public IQueryable<ContentOfIncomingTransaction> GetContentOfIncomingTransaction()
        {
            return db.ContentOfIncomingTransaction;
        }

        // GET: api/ContentOfIncomingTransactions/5
        [ResponseType(typeof(ContentOfIncomingTransaction))]
        public IHttpActionResult GetContentOfIncomingTransaction(int id)
        {
            ContentOfIncomingTransaction contentOfIncomingTransaction = db.ContentOfIncomingTransaction.Find(id);
            if (contentOfIncomingTransaction == null)
            {
                return NotFound();
            }

            return Ok(contentOfIncomingTransaction);
        }

        // PUT: api/ContentOfIncomingTransactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContentOfIncomingTransaction(int id, ContentOfIncomingTransaction contentOfIncomingTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentOfIncomingTransaction.id)
            {
                return BadRequest();
            }

            db.Entry(contentOfIncomingTransaction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentOfIncomingTransactionExists(id))
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

        // POST: api/ContentOfIncomingTransactions
        [ResponseType(typeof(ContentOfIncomingTransaction))]
        public IHttpActionResult PostContentOfIncomingTransaction(ContentOfIncomingTransaction contentOfIncomingTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContentOfIncomingTransaction.Add(contentOfIncomingTransaction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contentOfIncomingTransaction.id }, contentOfIncomingTransaction);
        }

        // DELETE: api/ContentOfIncomingTransactions/5
        [ResponseType(typeof(ContentOfIncomingTransaction))]
        public IHttpActionResult DeleteContentOfIncomingTransaction(int id)
        {
            ContentOfIncomingTransaction contentOfIncomingTransaction = db.ContentOfIncomingTransaction.Find(id);
            if (contentOfIncomingTransaction == null)
            {
                return NotFound();
            }

            db.ContentOfIncomingTransaction.Remove(contentOfIncomingTransaction);
            db.SaveChanges();

            return Ok(contentOfIncomingTransaction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContentOfIncomingTransactionExists(int id)
        {
            return db.ContentOfIncomingTransaction.Count(e => e.id == id) > 0;
        }
    }
}