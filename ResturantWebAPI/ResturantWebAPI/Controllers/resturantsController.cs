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
using ResturantWebAPI.Models;

namespace ResturantWebAPI.Controllers
{
    public class resturantsController : ApiController
    {
        private resturantDBEntities db = new resturantDBEntities();

        // GET: api/resturants
        public IQueryable<resturant> Getresturants()
        {
            return db.resturants;
        }

        // GET: api/resturants/5
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

        // PUT: api/resturants/5
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

            db.Entry(resturant).State = System.Data.EntityState.Modified;

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

        // POST: api/resturants
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

        // DELETE: api/resturants/5
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