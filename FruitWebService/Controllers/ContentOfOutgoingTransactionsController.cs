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
    public class ContentOfOutgoingTransactionsController : ApiController
    {
        private FruitModel db = new FruitModel();

        // GET: api/ContentOfOutgoingTransactions
        public IQueryable<ContentOfOutgoingTransaction> GetContentOfOutgoingTransaction()
        {
            return db.ContentOfOutgoingTransaction;
        }

        // GET: api/ContentOfOutgoingTransactions/5
        [ResponseType(typeof(ContentOfOutgoingTransaction))]
        public IHttpActionResult GetContentOfOutgoingTransaction(int id)
        {
            ContentOfOutgoingTransaction contentOfOutgoingTransaction = db.ContentOfOutgoingTransaction.Find(id);
            if (contentOfOutgoingTransaction == null)
            {
                return NotFound();
            }

            return Ok(contentOfOutgoingTransaction);
        }

        // PUT: api/ContentOfOutgoingTransactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContentOfOutgoingTransaction(int id, ContentOfOutgoingTransaction contentOfOutgoingTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentOfOutgoingTransaction.id)
            {
                return BadRequest();
            }

            db.Entry(contentOfOutgoingTransaction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentOfOutgoingTransactionExists(id))
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

        // POST: api/ContentOfOutgoingTransactions
        [ResponseType(typeof(ContentOfOutgoingTransaction))]
        public IHttpActionResult PostContentOfOutgoingTransaction(ContentOfOutgoingTransaction contentOfOutgoingTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContentOfOutgoingTransaction.Add(contentOfOutgoingTransaction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contentOfOutgoingTransaction.id }, contentOfOutgoingTransaction);
        }

        // DELETE: api/ContentOfOutgoingTransactions/5
        [ResponseType(typeof(ContentOfOutgoingTransaction))]
        public IHttpActionResult DeleteContentOfOutgoingTransaction(int id)
        {
            ContentOfOutgoingTransaction contentOfOutgoingTransaction = db.ContentOfOutgoingTransaction.Find(id);
            if (contentOfOutgoingTransaction == null)
            {
                return NotFound();
            }

            db.ContentOfOutgoingTransaction.Remove(contentOfOutgoingTransaction);
            db.SaveChanges();

            return Ok(contentOfOutgoingTransaction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContentOfOutgoingTransactionExists(int id)
        {
            return db.ContentOfOutgoingTransaction.Count(e => e.id == id) > 0;
        }
    }
}