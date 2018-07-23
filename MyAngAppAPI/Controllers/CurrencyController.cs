﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MyAngAppAPI.Models;

namespace MyAngAppAPI.Controllers
{
    public class CurrencyController : ApiController
    {
        private CurrencyContext db = new CurrencyContext();

        // GET: api/Currency
        public IQueryable<Currency> GetCurrencies()
        {
            return db.Currencies.Where(x => x.ClientNo == 101).AsQueryable(); ;
        }

        // GET: api/Currency/5
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> GetCurrency(int id)
        {
            Currency currency = await db.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // PUT: api/Currency/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCurrency(int id, Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currency.CurrencyId)
            {
                return BadRequest();
            }

            db.Entry(currency).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        // POST: api/Currency
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> PostCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Currencies.Add(currency);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = currency.CurrencyId }, currency);
        }

        // DELETE: api/Currency/5
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> DeleteCurrency(int id)
        {
            Currency currency = await db.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            db.Currencies.Remove(currency);
            await db.SaveChangesAsync();

            return Ok(currency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrencyExists(int id)
        {
            return db.Currencies.Count(e => e.CurrencyId == id) > 0;
        }
    }
}