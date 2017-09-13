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
    public class ProcessedOutgoingTransactionsController : ApiController
    {
        private FruitDBModels db = new FruitDBModels();

        // GET: api/ProcessedOutgoingTransactions
        public IQueryable<ProcessedOutgoingTransactions> GetProcessedOutgoingTransactions()
        {
            return db.ProcessedOutgoingTransactions;
        }

        // GET: api/ProcessedOutgoingTransactions/5
        [ResponseType(typeof(ProcessedOutgoingTransactions))]
        public IHttpActionResult GetProcessedOutgoingTransactions(int id)
        {
            ProcessedOutgoingTransactions processedOutgoingTransactions = db.ProcessedOutgoingTransactions.Find(id);
            if (processedOutgoingTransactions == null)
            {
                return NotFound();
            }

            return Ok(processedOutgoingTransactions);
        }

        // PUT: api/ProcessedOutgoingTransactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProcessedOutgoingTransactions(int id, ProcessedOutgoingTransactions processedOutgoingTransactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != processedOutgoingTransactions.id)
            {
                return BadRequest();
            }

            db.Entry(processedOutgoingTransactions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessedOutgoingTransactionsExists(id))
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

        // POST: api/ProcessedOutgoingTransactions
        [ResponseType(typeof(ProcessedOutgoingTransactions))]
        public IHttpActionResult PostProcessedOutgoingTransactions(ProcessedOutgoingTransactions processedOutgoingTransactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProcessedOutgoingTransactions.Add(processedOutgoingTransactions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = processedOutgoingTransactions.id }, processedOutgoingTransactions);
        }

        // DELETE: api/ProcessedOutgoingTransactions/5
        [ResponseType(typeof(ProcessedOutgoingTransactions))]
        public IHttpActionResult DeleteProcessedOutgoingTransactions(int id)
        {
            ProcessedOutgoingTransactions processedOutgoingTransactions = db.ProcessedOutgoingTransactions.Find(id);
            if (processedOutgoingTransactions == null)
            {
                return NotFound();
            }

            db.ProcessedOutgoingTransactions.Remove(processedOutgoingTransactions);
            db.SaveChanges();

            return Ok(processedOutgoingTransactions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcessedOutgoingTransactionsExists(int id)
        {
            return db.ProcessedOutgoingTransactions.Count(e => e.id == id) > 0;
        }
    }
}