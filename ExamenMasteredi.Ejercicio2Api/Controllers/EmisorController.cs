using System;
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
using ExamenMasteredi.Ejercicio2.Domain.Entities;
using ExamenMasteredi.Ejercicio2Api.Models;

namespace ExamenMasteredi.Ejercicio2Api.Controllers
{
    public class EmisorController : ApiController
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: api/Emisor
        public IQueryable<EmisorEntity> GetEmisors()
        {
            return db.Emisors;
        }

        // GET: api/Emisor/5
        [ResponseType(typeof(EmisorEntity))]
        public async Task<IHttpActionResult> GetEmisorEntity(string id)
        {
            EmisorEntity emisorEntity = await db.Emisors.FindAsync(id);
            if (emisorEntity == null)
            {
                return NotFound();
            }

            return Ok(emisorEntity);
        }

        // PUT: api/Emisor/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmisorEntity(string id, EmisorEntity emisorEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emisorEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(emisorEntity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmisorEntityExists(id))
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

        // POST: api/Emisor
        [ResponseType(typeof(EmisorEntity))]
        public async Task<IHttpActionResult> PostEmisorEntity(EmisorEntity emisorEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            emisorEntity.Id = Guid.NewGuid().ToString();
            db.Emisors.Add(emisorEntity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmisorEntityExists(emisorEntity.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = emisorEntity.Id }, emisorEntity);
        }

        // DELETE: api/Emisor/5
        [ResponseType(typeof(EmisorEntity))]
        public async Task<IHttpActionResult> DeleteEmisorEntity(string id)
        {
            EmisorEntity emisorEntity = await db.Emisors.FindAsync(id);
            if (emisorEntity == null)
            {
                return NotFound();
            }

            db.Emisors.Remove(emisorEntity);
            await db.SaveChangesAsync();

            return Ok(emisorEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmisorEntityExists(string id)
        {
            return db.Emisors.Count(e => e.Id == id) > 0;
        }
    }
}