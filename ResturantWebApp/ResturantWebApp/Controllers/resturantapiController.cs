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
using ResturantWebApp.Models;

namespace ResturantWebApp.Controllers
{
    public class resturantapiController : ApiController
    {
        private resturantDBEntities db = new resturantDBEntities();

        // GET: api/resturantapi
        public IQueryable<resturant> Getresturants()
        {
            return db.resturants;
        }

        // GET: api/resturantapi/5
        [ResponseType(typeof(resturant))]
        public IHttpActionResult Getresturant(int id)
        {
            resturant resturant = db.resturants.Find(id);
            if (resturant == null)
            {
                return NotFound();
            }

            return Ok(resturant);
        }

        // PUT: api/resturantapi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putresturant(int id, resturant resturant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resturant.resturantID)
            {
                return BadRequest();
            }

            db.Entry(resturant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!resturantExists(id))
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

        // POST: api/resturantapi
        [ResponseType(typeof(resturant))]
        public IHttpActionResult Postresturant(resturant resturant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.resturants.Add(resturant);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (resturantExists(resturant.resturantID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = resturant.resturantID }, resturant);
        }

        // DELETE: api/resturantapi/5
        [ResponseType(typeof(resturant))]
        public IHttpActionResult Deleteresturant(int id)
        {
            resturant resturant = db.resturants.Find(id);
            if (resturant == null)
            {
                return NotFound();
            }

            db.resturants.Remove(resturant);
            db.SaveChanges();

            return Ok(resturant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool resturantExists(int id)
        {
            return db.resturants.Count(e => e.resturantID == id) > 0;
        }
    }
}