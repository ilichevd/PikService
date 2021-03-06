﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLogic.ServiceFactory;
using BusinessLogic.DataTransferObjects;
using System.Threading.Tasks;

namespace PikService.Controllers
{
    public class CatalogsController : BaseController
    {
        public CatalogsController(IServiceFactory serviceFactory) : base(serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [AllowAnonymous]
        // GET: api/Catalogs
        public async Task<IEnumerable<CatalogDto>> GetCatalogs()
        {
            var result = await _serviceFactory.GetCatalogService().GetAllAsync();
            return result;
        }
/*
        // GET: api/Catalogs/5
        [ResponseType(typeof(CatalogDto))]
        public IHttpActionResult GetCatalog(int id)
        {
            CatalogDto catalog = db.catalogs.Find(id);
            if (catalog == null)
            {
                return NotFound();
            }

            return Ok(catalog);
        }

        // PUT: api/Catalogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatalog(int id, CatalogDto catalog)
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
        [ResponseType(typeof(CatalogDto))]
        public IHttpActionResult PostCatalog(CatalogDto catalog)
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
        [ResponseType(typeof(CatalogDto))]
        public IHttpActionResult DeleteCatalog(int id)
        {
            CatalogDto catalog = db.catalogs.Find(id);
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