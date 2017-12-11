using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccessLevel.Models;
using DataAccessLevel.UnitOfWork.Interfaces;

namespace PikService.Controllers
{
    public class CatalogsController : BaseController
    {
        public CatalogsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // GET: api/Catalogs
        public List<Catalog> GetCatalogs()
        {
            return uow.entities<Catalog>().Get(null);
        }
/*
        // GET: api/Catalogs/5
        [ResponseType(typeof(Catalog))]
        public IHttpActionResult GetCatalog(int id)
        {
            Catalog catalog = db.catalogs.Find(id);
            if (catalog == null)
            {
                return NotFound();
            }

            return Ok(catalog);
        }

        // PUT: api/Catalogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatalog(int id, Catalog catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalog.CatalogId)
            {
                return BadRequest();
            }

            db.Entry(catalog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(id))
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

        // POST: api/Catalogs
        [ResponseType(typeof(Catalog))]
        public IHttpActionResult PostCatalog(Catalog catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.catalogs.Add(catalog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = catalog.CatalogId }, catalog);
        }

        // DELETE: api/Catalogs/5
        [ResponseType(typeof(Catalog))]
        public IHttpActionResult DeleteCatalog(int id)
        {
            Catalog catalog = db.catalogs.Find(id);
            if (catalog == null)
            {
                return NotFound();
            }

            db.catalogs.Remove(catalog);
            db.SaveChanges();

            return Ok(catalog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalogExists(int id)
        {
            return db.catalogs.Count(e => e.CatalogId == id) > 0;
        }*/
    }
}