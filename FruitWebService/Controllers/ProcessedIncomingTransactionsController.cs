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
    public class ProcessedIncomingTransactionsController : ApiController
    {
        private FruitDBModels db = new FruitDBModels();

        // GET: api/ProcessedIncomingTransactions
        public IQueryable<ProcessedIncomingTransactions> GetProcessedIncomingTransactions()
        {
            return db.ProcessedIncomingTransactions;
        }

        // GET: api/ProcessedIncomingTransactions/5
        [ResponseType(typeof(ProcessedIncomingTransactions))]
        public IHttpActionResult GetProcessedIncomingTransactions(int id)
        {
            ProcessedIncomingTransactions processedIncomingTransactions = db.ProcessedIncomingTransactions.Find(id);
            if (processedIncomingTransactions == null)
            {
                return NotFound();
            }

            return Ok(processedIncomingTransactions);
        }

        // PUT: api/ProcessedIncomingTransactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProcessedIncomingTransactions(int id, ProcessedIncomingTransactions processedIncomingTransactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != processedIncomingTransactions.id)
            {
                return BadRequest();
            }

            db.Entry(processedIncomingTransactions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessedIncomingTransactionsExists(id))
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

        // POST: api/ProcessedIncomingTransactions
        [ResponseType(typeof(ProcessedIncomingTransactions))]
        public IHttpActionResult PostProcessedIncomingTransactions(ProcessedIncomingTransactions processedIncomingTransactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProcessedIncomingTransactions.Add(processedIncomingTransactions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = processedIncomingTransactions.id }, processedIncomingTransactions);
        }

        // DELETE: api/ProcessedIncomingTransactions/5
        [ResponseType(typeof(ProcessedIncomingTransactions))]
        public IHttpActionResult DeleteProcessedIncomingTransactions(int id)
        {
            ProcessedIncomingTransactions processedIncomingTransactions = db.ProcessedIncomingTransactions.Find(id);
            if (processedIncomingTransactions == null)
            {
                return NotFound();
            }

            db.ProcessedIncomingTransactions.Remove(processedIncomingTransactions);
            db.SaveChanges();

            return Ok(processedIncomingTransactions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcessedIncomingTransactionsExists(int id)
        {
            return db.ProcessedIncomingTransactions.Count(e => e.id == id) > 0;
        }
    }
}